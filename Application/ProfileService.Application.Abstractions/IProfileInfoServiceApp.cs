using ProfileService.Application.Contracts.ProfileInfoContracts;

namespace ProfileService.Application.Abstractions;

public interface IProfileInfoServiceApp
{
    /// <summary>
    /// Получить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля. </returns>
    Task<ProfileInfoDto> GetByIdAsync(Guid id);

    /// <summary>
    /// Создать профиль.
    /// </summary>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля. </param>
    Task<Guid> CreateAsync(CreatingProfileInfoDto creatingProfileDto);

    /// <summary>
    /// Обновить курс и состав уроков.
    /// Для показа unit of work.
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="updatingCourseWithLessonsDto"></param>
    //Task UpdatingWithLessonsAsync(int id, UpdatingCourseWithLessonsDto updatingCourseWithLessonsDto);

    /// <summary>
    /// Изменить профиль.
    /// </summary>
    /// <param name="id"> Иентификатор. </param>
    /// <param name="updatingProfileDto"> ДТО редактируемого профиля. </param>
    Task UpdateAsync(Guid id, UpdatingProfileInfoDto updatingProfileDto);

    /// <summary>
    /// Удалить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей. </returns>
    Task<ICollection<ProfileInfoDto>> GetPagedAsync(int page, int pageSize);
}
