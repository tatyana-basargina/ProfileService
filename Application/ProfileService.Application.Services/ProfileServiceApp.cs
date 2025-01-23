using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities.Enums;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

/// <summary>
/// Cервис работы с профилями.
/// </summary>
public class ProfileServiceApp : IProfileServiceApp
{
    private readonly IMapper _mapper;
    private readonly IProfileRepository _profileRepository;
    //private readonly ILessonRepository _lessonRepository;
    //private readonly IBusControl _busControl;
    //private readonly IUnitOfWork _unitOfWork;

    public ProfileServiceApp(
            IMapper mapper,
            IProfileRepository profileRepository
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
    public async Task<ProfileDto> GetByIdAsync(Guid id)
    {
        var profile = await _profileRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<ProfileInfo, ProfileDto>(profile);
    }
    /// <summary>
    /// Создать профиль.
    /// </summary>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля. </param>
    public async Task<Guid> CreateAsync(CreatingProfileDto creatingProfileDto)
    {
        var profile = _mapper.Map<CreatingProfileDto, ProfileInfo>(creatingProfileDto);
        var createdCourse = await _profileRepository.AddAsync(profile);
        await _profileRepository.SaveChangesAsync();
        return createdCourse.Id;
    }
    /// <summary>
    /// Изменить профиль.
    /// </summary>
    /// <param name="id"> Иентификатор. </param>
    /// <param name="updatingProfileDto"> ДТО редактируемого профиля. </param>
    public async Task UpdateAsync(Guid id, UpdatingProfileDto updatingProfileDto)
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
    /// Получить постраничный список уроков.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница уроков. </returns>
    public async Task<ICollection<ProfileDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<ProfileInfo> entities = await _profileRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<ProfileInfo>, ICollection<ProfileDto>>(entities);
    }
}
