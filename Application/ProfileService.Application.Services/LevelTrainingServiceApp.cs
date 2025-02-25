using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.LevelTrainingContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

public class LevelTrainingServiceApp: ILevelTrainingServiceApp
{
    private readonly IMapper _mapper;
    private readonly ILevelTrainingRepository _levelTrainingRepository;

    public LevelTrainingServiceApp(
            IMapper mapper,
            ILevelTrainingRepository levelTrainingRepository
        )
    {
        _mapper = mapper;
        _levelTrainingRepository = levelTrainingRepository;
    }

    /// <summary>
    /// Получить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    /// <returns> ДТО уровня подготовки. </returns>
    public async Task<LevelTrainingDto> GetByIdAsync(int id)
    {
        var levelTraining = await _levelTrainingRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<LevelTraining, LevelTrainingDto>(levelTraining);
    }
    /// <summary>
    /// Создать уровень подготовки.
    /// </summary>
    /// <param name="creatingLevelTrainingDto"> ДТО создаваемого уровня подготовки. </param>
    public async Task<int> CreateAsync(CreatingLevelTrainingDto creatingLevelTrainingDto)
    {
        var levelTraining = _mapper.Map<CreatingLevelTrainingDto, LevelTraining>(creatingLevelTrainingDto);
        var createdLevelTraining = await _levelTrainingRepository.AddAsync(levelTraining);
        await _levelTrainingRepository.SaveChangesAsync();
        return createdLevelTraining.Id;
    }
    /// <summary>
    /// Изменить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    /// <param name="updatingLevelTrainingDto"> ДТО редактируемого уровня подготовки. </param>
    public async Task UpdateAsync(int id, UpdatingLevelTrainingDto updatingLevelTrainingDto)
    {
        var levelTraining = await _levelTrainingRepository.GetAsync(id, CancellationToken.None);
        if (levelTraining == null)
        {
            throw new Exception($"Уровень подготовки с идентфикатором {id} не найден");
        }

        levelTraining.Name = updatingLevelTrainingDto.Name;

        _levelTrainingRepository.Update(levelTraining);
        await _levelTrainingRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Удалить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    public async Task DeleteAsync(int id)
    {
        var levelTraining = await _levelTrainingRepository.GetAsync(id, CancellationToken.None);
        _levelTrainingRepository.Delete(levelTraining);
        await _levelTrainingRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница. </returns>
    public async Task<ICollection<LevelTrainingDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<LevelTraining> entities = await _levelTrainingRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<LevelTraining>, ICollection<LevelTrainingDto>>(entities);
    }
}