using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Common.Enums;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;
/// <summary>
/// Cервис работы с профилями инструктора.
/// </summary>
public class InstructorProfileInfoServiceApp : IInstructorProfileInfoServiceApp
{
    private readonly IMapper _mapper;
    private readonly IInstructorProfileInfoRepository _instructorProfileRepository;

    public InstructorProfileInfoServiceApp(
            IMapper mapper,
            IInstructorProfileInfoRepository profileRepository
        )
    {
        _mapper = mapper;
        _instructorProfileRepository = profileRepository;
    }

    /// <summary>
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор профиля инструктора. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    public async Task<InstructorProfileInfoDto> GetByIdAsync(Guid id)
    {
        var instructorProfile = await _instructorProfileRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<InstructorProfileInfo, InstructorProfileInfoDto>(instructorProfile);
    }

    /// <summary>
    /// Получить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    public async Task<InstructorProfileInfoDto> GetByUserIdAsync(Guid userId)
    {
        var instructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        return _mapper.Map<InstructorProfileInfo?, InstructorProfileInfoDto>(instructorProfile);
    }

    public async Task<InstructorProfileInfoDto> GetByUserIdAndStatusAsync(Guid userId, ProfileStatuses profileStatus)
    {
        var instructorProfile = await _instructorProfileRepository.GetByUserIdAndStatusAsync(userId, profileStatus);
        return _mapper.Map<InstructorProfileInfo?, InstructorProfileInfoDto>(instructorProfile);
    }

    /// <summary>
    /// Создать профиль инструктора.
    /// </summary>
    /// <param name="creatingInstructorProfile"> Профиль инструктора. </param>
    public async Task<Guid> CreateAsync(InstructorProfileInfo creatingInstructorProfile)
    {
        InstructorProfileInfo instructorProfile = creatingInstructorProfile;

        instructorProfile.Id = Guid.NewGuid();
        instructorProfile.ProfileType = ProfileType.Instructor;
        instructorProfile.CreatedDate = DateTime.UtcNow;
        instructorProfile.IsActive = false;
        instructorProfile.IsDeleted = false;
        instructorProfile.IsCurrentVersion = true;

        var createdInstructorProfile = await _instructorProfileRepository.AddAsync(instructorProfile);

        await _instructorProfileRepository.SaveChangesAsync();

        return createdInstructorProfile.Id;
    }

    /// <summary>
    /// Изменить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="updatingInstructorProfileDto"> ДТО редактируемого профиля инструктора. </param>
    public async Task UpdateAsync(Guid userId, UpdatingInstructorProfileInfoDto updatingInstructorProfileDto)
    {
        InstructorProfileInfo? currentInstructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        if (currentInstructorProfile == null)
        {
            throw new Exception($"Профиль инструктора пользователя с идентфикатором {userId} не найден");
        }

        InstructorProfileInfoDto? instructorProfileRequiredConfirmation = GetByUserIdAndStatusAsync(userId, ProfileStatuses.RequiredConfirmation).Result;

        if (currentInstructorProfile.Status == ProfileStatuses.Changed && instructorProfileRequiredConfirmation != null)
        {
            throw new Exception($"Изменения профиля инструктора не подтверждены. Изменение невозможно.");
        }

        InstructorProfileInfo instructorProfile = _mapper.Map<UpdatingInstructorProfileInfoDto, InstructorProfileInfo>(updatingInstructorProfileDto);
        currentInstructorProfile.UpdatedDate = DateTime.UtcNow;
        currentInstructorProfile.Status = ProfileStatuses.Changed;
        currentInstructorProfile.IsActive = true;
        currentInstructorProfile.IsDeleted = false;
        currentInstructorProfile.IsCurrentVersion = false;


        instructorProfile.UserId = userId;
        instructorProfile.VersionNumber = currentInstructorProfile.VersionNumber + 1;
        instructorProfile.Status = ProfileStatuses.RequiredConfirmation;

        await CreateAsync(instructorProfile);

        await _instructorProfileRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Подтверждение изменений профиля
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="profileStatus"> Статус профиля. </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task ConfirmСhangesAsync(Guid userId, ProfileStatuses profileStatus)
    {
        InstructorProfileInfo? currentInstructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        if (currentInstructorProfile == null)
        {
            throw new Exception($"Профиль инструктора пользователя с идентфикатором {userId} не найден");
        }

        if (currentInstructorProfile.Status != ProfileStatuses.RequiredConfirmation && currentInstructorProfile.Status != ProfileStatuses.Changed)
        {
            throw new Exception($"Изменения профиля инструктора не требуют подтверждения");
        }

        if (profileStatus != ProfileStatuses.Confirmed && profileStatus != ProfileStatuses.Rejected)
        {
            throw new Exception($"Некорректный статус профиля для подтверждения или отмены изменений");
        }

        InstructorProfileInfo? requiredConfirmationInstructorProfile = await _instructorProfileRepository.GetByUserIdAndStatusAsync(userId, ProfileStatuses.RequiredConfirmation);
        if (requiredConfirmationInstructorProfile == null)
        {
            throw new Exception($"Профиль инструктора пользователя с идентфикатором {userId} не найден");
        }

        bool isConfirmed = profileStatus == ProfileStatuses.Confirmed;

        currentInstructorProfile.IsActive = !isConfirmed;

        requiredConfirmationInstructorProfile.IsActive = isConfirmed;
        requiredConfirmationInstructorProfile.Status = profileStatus;

        await _instructorProfileRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    public async Task DeleteAsync(Guid userId)
    {
        var instructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        if (instructorProfile == null)
        {
            throw new Exception($"Профиль инструктора пользователя с идентфикатором {userId} не найден");
        }
        instructorProfile.UpdatedDate = DateTime.UtcNow;
        instructorProfile.Status = ProfileStatuses.Hidden;
        instructorProfile.IsActive = false;
        instructorProfile.IsDeleted = true;
        instructorProfile.UpdatedUserId = userId;
        await _instructorProfileRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Получить постраничный список профилей инструктора.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Страница профилей инструктора. </returns>
    public async Task<ICollection<InstructorProfileInfoDto>> GetPagedAsync(int page, int itemsPerPage)
    {
        ICollection<InstructorProfileInfo> entities = await _instructorProfileRepository.GetPagedAsync(page, itemsPerPage);
        return _mapper.Map<ICollection<InstructorProfileInfo>, ICollection<InstructorProfileInfoDto>>(entities);
    }

    /// <summary>
    /// Получить cписок профилей инструктора требующих подтверждение изменений
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns></returns>
    public async Task<ICollection<InstructorProfileInfoDto>> GetRequiredConfirmationAsync(int page, int itemsPerPage)
    {
        ICollection<InstructorProfileInfo> entities = await _instructorProfileRepository.GetRequiredConfirmationPagedAsync(page, itemsPerPage);
        return _mapper.Map<ICollection<InstructorProfileInfo>, ICollection<InstructorProfileInfoDto>>(entities);
    }
}
