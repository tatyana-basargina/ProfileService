using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.AchievementContracts;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Common.Enums;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

public class AchievementServiceApp: IAchievementServiceApp
{
    private readonly IMapper _mapper;
    private readonly IAchievementRepository _achievementRepository;
    //private readonly ILessonRepository _lessonRepository;
    //private readonly IBusControl _busControl;
    //private readonly IUnitOfWork _unitOfWork;

    public AchievementServiceApp(
            IMapper mapper,
            IAchievementRepository profileRepository
        //ILessonRepository lessonRepository,
        //IUnitOfWork unitOfWork,
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _achievementRepository = profileRepository;
        //_lessonRepository = lessonRepository;
        //_busControl = busControl;
        //_unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО . </returns>
    public async Task<Contracts.AchievementContracts.AchievementDto> GetByIdAsync(int id)
    {
        var achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<Achievement, Contracts.AchievementContracts.AchievementDto>(achievement);
    }
    /// <summary>
    /// Создать .
    /// </summary>
    /// <param name="creatingAchievementDto"> ДТО создаваемого . </param>
    public async Task<int> CreateAsync(CreatingAchievementDto creatingAchievementDto)
    {
        var achievement = _mapper.Map<CreatingAchievementDto, Achievement>(creatingAchievementDto);
        var createdAchievement = await _achievementRepository.AddAsync(achievement);
        await _achievementRepository.SaveChangesAsync();
        return createdAchievement.Id;
    }
    /// <summary>
    /// Изменить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingAchievementDto"> ДТО редактируемого. </param>
    public async Task UpdateAsync(int id, UpdatingAchievementDto updatingAchievementDto)
    {
        var achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
        if (achievement == null)
        {
            throw new Exception($"Профиль с идентфикатором {id} не найден");
        }

        achievement.Title = updatingAchievementDto.Title;
        achievement.Description = updatingAchievementDto.Description;
        //achievement.ProfileInfoId = updatingAchievementDto.ProfileInfo.Id;
        //achievement.ProfileInfo = updatingAchievementDto.ProfileInfo;
        //achievement.FilesAchievement = updatingAchievementDto.FilesAchievement;

        _achievementRepository.Update(achievement);
        await _achievementRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить .
    /// </summary>
    /// <param name="id"> Идентификатор . </param>
    public async Task DeleteAsync(int id)
    {
        var achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
        _achievementRepository.Delete(achievement);
        await _achievementRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница . </returns>
    public async Task<ICollection<AchievementDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<Achievement> entities = await _achievementRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<Achievement>, ICollection<AchievementDto>>(entities);
    }
}