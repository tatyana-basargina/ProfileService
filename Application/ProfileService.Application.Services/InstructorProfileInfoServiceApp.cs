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
    //private readonly IBusControl _busControl;
    //private readonly IUnitOfWork _unitOfWork;

    public InstructorProfileInfoServiceApp(
            IMapper mapper,
            IInstructorProfileInfoRepository profileRepository
        //IUnitOfWork unitOfWork,
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _instructorProfileRepository = profileRepository;
        //_busControl = busControl;
        //_unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    public async Task<InstructorProfileInfoDto> GetByIdAsync(Guid id)
    {
        var profile = await _instructorProfileRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<InstructorProfileInfo, InstructorProfileInfoDto>(profile);
    }
    /// <summary>
    /// Создать профиль инструктора.
    /// </summary>
    /// <param name="creatingInstructorProfileDto"> ДТО создаваемого профиля инструктора. </param>
    public async Task<Guid> CreateAsync(CreatingInstructorProfileInfoDto creatingInstructorProfileDto)
    {
        var instructorProfile = _mapper.Map<CreatingInstructorProfileInfoDto, InstructorProfileInfo>(creatingInstructorProfileDto);
        var createdInstructorProfile = await _instructorProfileRepository.AddAsync(instructorProfile);
        createdInstructorProfile.Id = Guid.NewGuid();
        createdInstructorProfile.CreatedDate = DateTime.Now;
        createdInstructorProfile.Status = ProfileStatuses.Created;
        createdInstructorProfile.IsActive = true;
        createdInstructorProfile.IsDeleted = false;

        await _instructorProfileRepository.SaveChangesAsync();
        return createdInstructorProfile.Id;
    }

    public async Task<Guid> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoDto creatingInstructorProfileDto)
    {
        var instructorProfile = _mapper.Map<CreatingInstructorProfileInfoDto, InstructorProfileInfo>(creatingInstructorProfileDto);
        var createdInstructorProfile = await _instructorProfileRepository.AddAsync(instructorProfile);
        createdInstructorProfile.Id = Guid.NewGuid();
        createdInstructorProfile.UserId = userId;
        createdInstructorProfile.CreatedDate = DateTime.Now;
        createdInstructorProfile.Status = ProfileStatuses.Created;
        createdInstructorProfile.IsActive = true;
        createdInstructorProfile.IsDeleted = false;

        await _instructorProfileRepository.SaveChangesAsync();
        return createdInstructorProfile.Id;
    }

    /// <summary>
    /// Изменить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор инструктора. </param>
    /// <param name="updatingInstructorProfileDto"> ДТО редактируемого профиля инструктора. </param>
    public async Task UpdateAsync(Guid id, UpdatingInstructorProfileInfoDto updatingInstructorProfileDto)
    {
        var instructorProfile = await _instructorProfileRepository.GetAsync(id, CancellationToken.None);
        if (instructorProfile == null)
        {
            throw new Exception($"Профиль инструктора с идентфикатором {id} не найден");
        }

        instructorProfile.UpdatedDate = updatingInstructorProfileDto.UpdatedDate;
        instructorProfile.Status = updatingInstructorProfileDto.Status;
        instructorProfile.IsActive = updatingInstructorProfileDto.IsActive;
        instructorProfile.IsDeleted = updatingInstructorProfileDto.IsDeleted;
        instructorProfile.UpdatedUserId = updatingInstructorProfileDto.UpdatedUserId;
        instructorProfile.PhotoId = updatingInstructorProfileDto.PhotoId;
        instructorProfile.Surname = updatingInstructorProfileDto.Surname;
        instructorProfile.Name = updatingInstructorProfileDto.Name;
        instructorProfile.Patronymic = updatingInstructorProfileDto.Patronymic;
        instructorProfile.BirthDate = updatingInstructorProfileDto.BirthDate;
        instructorProfile.Gender = updatingInstructorProfileDto.Gender;
        instructorProfile.PhoneNumber = updatingInstructorProfileDto.PhoneNumber;
        instructorProfile.TelegramName = updatingInstructorProfileDto.TelegramName;

        _instructorProfileRepository.Update(instructorProfile);
        await _instructorProfileRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Удалить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор профиля инструктора. </param>
    public async Task DeleteAsync(Guid id)
    {
        var instructorProfile = await _instructorProfileRepository.GetAsync(id, CancellationToken.None);
        //profile.UpdatedDate = DateTime.Now;
        //profile.Status = ProfileStatuses.Hidden;
        //profile.IsActive = false;
        //profile.IsDeleted = true;
        //profile.UpdatedUserId = Guid.Empty;// ?
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
