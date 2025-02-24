using ProfileService.Application.Contracts.InstructorProfileInfoContracts;

namespace ProfileService.Application.Abstractions;

public interface IInstructorProfileInfoServiceApp
{
    /// <summary>
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    Task<InstructorProfileInfoDto> GetByIdAsync(Guid id);

    /// <summary>
    /// Создать профиль инструктора.
    /// </summary>
    /// <param name="creatingInstructorProfileDto"> ДТО создаваемого профиля инструктора. </param>
    Task<Guid> CreateAsync(CreatingInstructorProfileInfoDto creatingInstructorProfileDto);

    /// <summary>
    /// Изменить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор инструктора. </param>
    /// <param name="updatingInstructorProfileDto"> ДТО редактируемого профиля инструктора. </param>
    Task UpdateAsync(Guid id, UpdatingInstructorProfileInfoDto updatingInstructorProfileDto);

    /// <summary>
    /// Удалить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор профиля инструктора. </param>
    Task DeleteAsync(Guid id);

    /// Получить постраничный список профилей инструктора.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница профилей инструктора. </returns>
    Task<ICollection<InstructorProfileInfoDto>> GetPagedAsync(int page, int pageSize);
}
