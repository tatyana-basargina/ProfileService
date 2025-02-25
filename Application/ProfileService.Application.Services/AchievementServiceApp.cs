using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.AchievementContracts;
using ProfileService.Application.Contracts.FileAchievementContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

public class AchievementServiceApp : IAchievementServiceApp
{
    private readonly IMapper _mapper;
    private readonly IAchievementRepository _achievementRepository;
    //private readonly IBusControl _busControl;
    private readonly IUnitOfWork _unitOfWork;

    public AchievementServiceApp(
            IMapper mapper,
            IAchievementRepository profileRepository,
            IUnitOfWork unitOfWork
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _achievementRepository = profileRepository;
        //_lessonRepository = lessonRepository;
        //_busControl = busControl;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить достижение со списком файлов.
    /// </summary>
    /// <param name="id"> Идентификатор достижения. </param>
    /// <returns> ДТО достижения со списком файлов. </returns>
    public async Task<AchievementDto> GetByIdAsync(int id)
    {

        var achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<Achievement, AchievementDto>(achievement);
    }

    /// <summary>
    /// Получить достижение со списком файлов.
    /// </summary>
    /// <param name="id"> Идентификатор пользователя. </param>
    /// <returns> ДТО достижения со списком файлов. </returns>
    //public async Task<AchievementDto> GetByUserIdAsync(Guid id)
    //{

    //    var achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
    //    return _mapper.Map<Achievement, AchievementDto>(achievement);
    //}

    /// <summary>
    /// Создать достижение со списком файлов.
    /// </summary>
    /// <param name="creatingAchievementWithFilesDto"> ДТО создаваемого достижения со списком файлов. </param>
    public async Task<int> CreateWithFilesAsync(CreatingAchievementWithFilesDto creatingAchievementWithFilesDto)
    {
        Achievement createdAchievement = _mapper.Map<CreatingAchievementWithFilesDto, Achievement>(creatingAchievementWithFilesDto);

        if (creatingAchievementWithFilesDto.FilesAchievement != null)
        {
            createdAchievement.FilesAchievement = _mapper.Map<IEnumerable<CreatingFileAchievementDto>, IEnumerable<FileAchievement>>(creatingAchievementWithFilesDto.FilesAchievement);
        }

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            createdAchievement = await _unitOfWork.AchievementRepository.AddAsync(createdAchievement);
            if (createdAchievement.FilesAchievement != null)
            {
                foreach (var file in createdAchievement.FilesAchievement)
                {
                    await _unitOfWork.FileAchievementRepository.AddAsync(file);
                }
            }

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }

        return createdAchievement.Id;
    }

    /// <summary>
    /// Изменить достижение.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingAchievementDto"> ДТО редактируемого достижения. </param>
    public async Task UpdateAsync(int id, UpdatingAchievementDto updatingAchievementDto)
    {
        Achievement achievement = await _achievementRepository.GetAsync(id, CancellationToken.None);
        if (achievement == null)
        {
            throw new Exception($"Достижение с идентфикатором {id} не найдено");
        }

        achievement.Title = updatingAchievementDto.Title;
        achievement.Description = updatingAchievementDto.Description;
        _achievementRepository.Update(achievement);
        await _achievementRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить достижение со списком файлов.
    /// </summary>
    /// <param name="id"> Идентификатор достижения со списком файлов. </param>
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