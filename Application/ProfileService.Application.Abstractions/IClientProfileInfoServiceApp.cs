using ProfileService.Application.Contracts.ClientProfileInfoContracts;

namespace ProfileService.Application.Abstractions;

public interface IClientProfileInfoServiceApp
{
    /// <summary>
    /// Получить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля. </returns>
    Task<ClientProfileInfoDto> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить профиль пользователя.
    /// </summary>
    /// <param name="id"> Идентификатор пользователя. </param>
    /// <returns> ДТО профиля пользователя. </returns>
    Task<ClientProfileInfoDto> GetByUserIdAsync(Guid userId);

    /// <summary>
    /// Создать профиль.
    /// </summary>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля. </param>
    Task<Guid> CreateAsync(Guid userId, CreatingClientProfileInfoDto creatingProfileDto);
    Task<Guid> CreateWithOwnerAsync(Guid ownerId, CreatingClientProfileInfoDto creatingProfileDto);

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
    Task UpdateAsync(Guid id, UpdatingClientProfileInfoDto updatingProfileDto);

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
    Task<IReadOnlyList<ClientProfileInfoDto>> GetPagedAsync(int page, int pageSize);
}
