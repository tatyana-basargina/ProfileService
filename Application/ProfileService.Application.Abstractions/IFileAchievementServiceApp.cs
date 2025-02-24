using ProfileService.Application.Contracts.FileAchievementContracts;

namespace ProfileService.Application.Abstractions;

public interface IFileAchievementServiceApp
{
    /// <summary>
    /// Получить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО . </returns>
    Task<FileAchievementDto> GetByIdAsync(int id);

    /// <summary>
    /// Создать .
    /// </summary>
    /// <param name="creatingFileAchievementDto"> ДТО создаваемого . </param>
    Task<int> CreateAsync(CreatingFileAchievementDto creatingFileAchievementDto);

    /// <summary>
    /// Обновить курс и состав уроков.
    /// Для показа unit of work.
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="updatingCourseWithLessonsDto"></param>
    //Task UpdatingWithLessonsAsync(int id, UpdatingCourseWithLessonsDto updatingCourseWithLessonsDto);

    /// <summary>
    /// Изменить .
    /// </summary>
    /// <param name="id"> Иентификатор. </param>
    /// <param name="updatingFileAchievementDto"> ДТО редактируемого . </param>
    Task UpdateAsync(int id, UpdatingFileAchievementDto updatingFileAchievementDto);

    /// <summary>
    /// Удалить .
    /// </summary>
    /// <param name="id"> Идентификатор . </param>
    Task DeleteAsync(int id);

    /// <summary>
    /// Получить список .
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница . </returns>
    //Task<ICollection<FileAchievementDto>> GetPagedAsync(int page, int pageSize);
}
