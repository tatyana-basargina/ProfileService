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
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns> ДТО профиля пользователя. </returns>
    Task<ClientProfileInfoDto> GetByUserIdAsync(Guid userId);

    /// <summary>
    /// Создать профиль.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля. </param>
    Task<Guid> CreateAsync(Guid userId, CreatingClientProfileInfoDto creatingProfileDto);

    /// <summary>
    /// Создать профиль клиента.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="ownerId"> Идентификатор пользователя. </param>
    /// <param name="creatingProfileDto"> ДТО создаваемого профиля клиента. </param>
    Task<Guid> CreateWithOwnerAsync(Guid userId, Guid? ownerId, CreatingClientProfileInfoDto creatingProfileDto);

    /// <summary>
    /// Изменить профиль клиента.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="updatingProfileDto"> ДТО редактируемого профиля клиента. </param>
    Task UpdateAsync(Guid userId, UpdatingClientProfileInfoDto updatingProfileDto);

    /// <summary>
    /// Удалить профиль клиента.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    Task DeleteAsync(Guid userId);

    /// <summary>
    /// Получить список профилей клиентов.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей клиентов. </returns>
    Task<IReadOnlyList<ClientProfileInfoDto>> GetPagedAsync(int page, int pageSize);
}
