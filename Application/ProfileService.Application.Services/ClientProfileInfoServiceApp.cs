using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Common.Enums;

namespace ProfileService.Application.Services;

/// <summary>
/// Cервис работы с профилями пользователя.
/// </summary>
public class ClientProfileInfoServiceApp: IClientProfileInfoServiceApp
{
    private readonly IMapper _mapper;
    private readonly IClientProfileInfoRepository _profileRepository;
    //private readonly ILessonRepository _lessonRepository;
    //private readonly IBusControl _busControl;
    //private readonly IUnitOfWork _unitOfWork;

    public ClientProfileInfoServiceApp(
            IMapper mapper,
            IClientProfileInfoRepository profileRepository
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
    /// Получить профиль пользователя.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля пользователя. </returns>
    public async Task<ClientProfileInfoDto> GetByIdAsync(Guid id)
    {
        var profile = await _profileRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<ClientProfileInfo, ClientProfileInfoDto>(profile);
    }
    /// <summary>
    /// Создать профиль пользователя.
    /// </summary>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля пользователя. </param>
    public async Task<Guid> CreateAsync(CreatingClientProfileInfoDto creatingProfileDto)
    {
        var profile = _mapper.Map<CreatingClientProfileInfoDto, ClientProfileInfo>(creatingProfileDto);
        var createdCourse = await _profileRepository.AddAsync(profile);
        await _profileRepository.SaveChangesAsync();
        return createdCourse.Id;
    }
    /// <summary>
    /// Изменить профиль пользователя.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingProfileDto"> ДТО редактируемого профиля пользователя. </param>
    public async Task UpdateAsync(Guid id, UpdatingClientProfileInfoDto updatingProfileDto)
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
    /// Удалить профиль пользователя.
    /// </summary>
    /// <param name="id"> Идентификатор профиля пользователя. </param>
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
    /// Получить постраничный список профилей пользователя.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей пользователя. </returns>
    public async Task<ICollection<ClientProfileInfoDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<ClientProfileInfo> entities = await _profileRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<ClientProfileInfo>, ICollection<ClientProfileInfoDto>>(entities);
    }
}