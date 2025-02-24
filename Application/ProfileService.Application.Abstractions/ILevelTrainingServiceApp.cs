using ProfileService.Application.Contracts.LevelTrainingContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Abstractions;

public interface ILevelTrainingServiceApp
{
    /// <summary>
    /// Получить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    /// <returns> ДТО уровня подготовки. </returns>
    Task<LevelTrainingDto> GetByIdAsync(int id);
    /// <summary>
    /// Создать уровень подготовки.
    /// </summary>
    /// <param name="creatingLevelTrainingDto"> ДТО создаваемого уровня подготовки. </param>
    Task<int> CreateAsync(CreatingLevelTrainingDto creatingLevelTrainingDto);
    /// <summary>
    /// Изменить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    /// <param name="updatingLevelTrainingDto"> ДТО редактируемого уровня подготовки. </param>
    Task UpdateAsync(int id, UpdatingLevelTrainingDto updatingLevelTrainingDto);
    /// <summary>
    /// Удалить уровень подготовки.
    /// </summary>
    /// <param name="id"> Идентификатор уровня подготовки. </param>
    Task DeleteAsync(int id);
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница. </returns>
    Task<ICollection<LevelTrainingDto>> GetPagedAsync(int page, int pageSize);
}
