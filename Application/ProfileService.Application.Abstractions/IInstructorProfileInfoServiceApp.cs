using ProfileService.Application.Contracts.InstructorProfileInfoContracts;

namespace ProfileService.Application.Abstractions;

public interface IInstructorProfileInfoServiceApp
{
    /// <summary>
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор профиля инструктора. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    Task<InstructorProfileInfoDto> GetByIdAsync(Guid id);

    /// <summary>
    /// Получить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    Task<InstructorProfileInfoDto> GetByUserIdAsync(Guid userId);

    /// <summary>
    /// Создать профиль инструктора.
    /// </summary>
    /// <param name="creatingInstructorProfileDto"> ДТО создаваемого профиля инструктора. </param>
    //Task<Guid> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoDto creatingInstructorProfileDto);

    /// <summary>
    /// Изменить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="updatingInstructorProfileDto"> ДТО редактируемого профиля инструктора. </param>
    /// <returns></returns>
    Task UpdateAsync(Guid userId, UpdatingInstructorProfileInfoDto updatingInstructorProfileDto);

    /// <summary>
    /// Удалить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор профиля инструктора. </param>
    /// <returns></returns>
    Task DeleteAsync(Guid userId);

    /// <summary>
    /// Получить постраничный список профилей инструктора.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Страница профилей инструктора. </returns>
    Task<ICollection<InstructorProfileInfoDto>> GetPagedAsync(int page, int itemsPerPage);
}
