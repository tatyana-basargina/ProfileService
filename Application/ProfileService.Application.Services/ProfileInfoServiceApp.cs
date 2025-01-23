using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities.Enums;
using ProfileService.Domain.Entities;
using ProfileService.Application.Contracts.ProfileInfoContracts;

namespace ProfileService.Application.Services;

/// <summary>
/// Cервис работы с профилями.
/// </summary>
public class ProfileInfoServiceApp : IProfileInfoServiceApp
{
    private readonly IMapper _mapper;
    private readonly IProfileInfoRepository _profileRepository;
    //private readonly ILessonRepository _lessonRepository;
    //private readonly IBusControl _busControl;
    //private readonly IUnitOfWork _unitOfWork;

    public ProfileInfoServiceApp(
            IMapper mapper,
            IProfileInfoRepository profileRepository
        //ILessonRepository lessonRepository,
        //IUnitOfWork unitOfWork,
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _profileRepository = profileRepository;
        //_lessonRepository = lessonRepository;
        //_busControl = busControl;
        //_unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля. </returns>
    public async Task<ProfileInfoDto> GetByIdAsync(Guid id)
    {
        var profile = await _profileRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<ProfileInfo, ProfileInfoDto>(profile);
    }
    /// <summary>
    /// Создать профиль.
    /// </summary>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля. </param>
    public async Task<Guid> CreateAsync(CreatingProfileInfoDto creatingProfileDto)
    {
        var profile = _mapper.Map<CreatingProfileInfoDto, ProfileInfo>(creatingProfileDto);
        var createdCourse = await _profileRepository.AddAsync(profile);
        await _profileRepository.SaveChangesAsync();
        return createdCourse.Id;
    }
    /// <summary>
    /// Изменить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingProfileDto"> ДТО редактируемого профиля. </param>
    public async Task UpdateAsync(Guid id, UpdatingProfileInfoDto updatingProfileDto)
    {
        var profile = await _profileRepository.GetAsync(id, CancellationToken.None);
        if (profile == null)
        {
            throw new Exception($"Профиль с идентфикатором {id} не найден");
        }

        profile.UpdatedDate = updatingProfileDto.UpdatedDate;
        profile.Status = updatingProfileDto.Status;
        profile.IsActive = updatingProfileDto.IsActive;
        profile.IsDeleted = updatingProfileDto.IsDeleted;
        profile.UpdatedUserId = updatingProfileDto.UpdatedUserId;
        profile.PhotoId = updatingProfileDto.PhotoId;
        profile.Surname = updatingProfileDto.Surname;
        profile.Name = updatingProfileDto.Name;
        profile.Patronymic = updatingProfileDto.Patronymic;
        profile.BirthDate = updatingProfileDto.BirthDate;
        profile.Gender = updatingProfileDto.Gender;
        profile.PhoneNumber = updatingProfileDto.PhoneNumber;
        profile.TelegramName = updatingProfileDto.TelegramName;

        _profileRepository.Update(profile);
        await _profileRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Удалить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    public async Task DeleteAsync(Guid id)
    {
        var profile = await _profileRepository.GetAsync(id, CancellationToken.None);
        profile.UpdatedDate = DateTime.Now;
        profile.Status = ProfileStatuses.Hidden;
        profile.IsActive = false;
        profile.IsDeleted = true;
        profile.UpdatedUserId = Guid.Empty;// ?
        await _profileRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Получить постраничный список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей. </returns>
    public async Task<ICollection<ProfileInfoDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<ProfileInfo> entities = await _profileRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<ProfileInfo>, ICollection<ProfileInfoDto>>(entities);
    }
}
