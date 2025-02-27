using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Common;
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
    //private readonly IBusControl _busControl;
    private readonly IUnitOfWork _unitOfWork;

    public InstructorProfileInfoServiceApp(
            IMapper mapper,
            IInstructorProfileInfoRepository profileRepository,
            IUnitOfWork unitOfWork
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _instructorProfileRepository = profileRepository;
        //_busControl = busControl;
        _unitOfWork = unitOfWork;
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
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    public async Task<InstructorProfileInfoDto> GetByUserIdAsync(Guid userId)
    {
        var instructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        return _mapper.Map<InstructorProfileInfo?, InstructorProfileInfoDto>(instructorProfile);
    }

    /// <summary>
    /// Создать профиль инструктора.
    /// </summary>
    /// <param name="creatingInstructorProfileDto"> ДТО создаваемого профиля инструктора. </param>
    public async Task<Guid> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoDto creatingInstructorProfileDto)
    {
        InstructorProfileInfo? currentInstructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);

        InstructorProfileInfo instructorProfile = _mapper.Map<CreatingInstructorProfileInfoDto, InstructorProfileInfo>(creatingInstructorProfileDto);
        InstructorProfileInfo createdInstructorProfile = await _instructorProfileRepository.AddAsync(instructorProfile);

        if (currentInstructorProfile != null)
        {
            currentInstructorProfile.IsActive = false;
            currentInstructorProfile.IsCurrentVersion = false;

            createdInstructorProfile.IsCurrentVersion = true;
            createdInstructorProfile.VersionNumber = currentInstructorProfile.VersionNumber + 1;
        }
        else
        {
            createdInstructorProfile.VersionNumber = 1;
        }

        createdInstructorProfile.Id = Guid.NewGuid();
        createdInstructorProfile.UserId = userId;
        createdInstructorProfile.ProfileType = ProfileType.Instructor;
        createdInstructorProfile.CreatedDate = DateTime.UtcNow;
        createdInstructorProfile.Status = ProfileStatuses.Created;
        createdInstructorProfile.IsActive = true;
        createdInstructorProfile.IsDeleted = false;

        await _instructorProfileRepository.SaveChangesAsync();
        return createdInstructorProfile.Id;
    }

    /// <summary>
    /// Изменить профиль инструктора.
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

        currentInstructorProfile.UpdatedDate = DateTime.UtcNow;
        currentInstructorProfile.Status = ProfileStatuses.Changed;
        currentInstructorProfile.IsActive = false;
        currentInstructorProfile.IsDeleted = false;
        currentInstructorProfile.UpdatedUserId = userId;

        InstructorProfileInfo instructorProfile = _mapper.Map<UpdatingInstructorProfileInfoDto, InstructorProfileInfo>(updatingInstructorProfileDto);
        var createdInstructorProfile = _mapper.Map<InstructorProfileInfo, CreatingInstructorProfileInfoDto>(instructorProfile);

        await CreateByUserIdAsync(userId, createdInstructorProfile);

        await _instructorProfileRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить профиль инструктора.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    public async Task DeleteAsync(Guid userId)
    {
        var instructorProfile = await _instructorProfileRepository.GetByUserIdAsync(userId, CancellationToken.None);
        if (instructorProfile == null)
        {
            throw new Exception($"Профиль инструктора пользователя с идентфикатором {userId} не найден");
        }
        instructorProfile.UpdatedDate = DateTime.Now;
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
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей инструктора. </returns>
    public async Task<ICollection<InstructorProfileInfoDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<InstructorProfileInfo> entities = await _instructorProfileRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<InstructorProfileInfo>, ICollection<InstructorProfileInfoDto>>(entities);
    }
}
