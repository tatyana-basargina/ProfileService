using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.InstructorProfileInfoModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using ProfileService.Common.Enums;

namespace ProfileService.API.Controllers.Profiles;

[ApiController]
[EnableCors("AllowReactApp")]
[Route("/api/[controller]")]
public class InstructorProfileInfoController : ControllerBase
{
    private readonly IInstructorProfileInfoServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<InstructorProfileInfoController> _logger;
    public InstructorProfileInfoController(
        IInstructorProfileInfoServiceApp service,
        ILogger<InstructorProfileInfoController> logger,
        IMapper mapper
    )
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить профиль инструктора.
    /// </summary>
    /// <param name="id"> Идентификатор профиля инструктора. </param>
    /// <returns> ДТО профиля инструктора. </returns>
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<InstructorProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    /// <summary>
    /// Получить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId)
    {
        return Ok(_mapper.Map<InstructorProfileInfoModel>(await _service.GetByUserIdAsync(userId)));
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoModel instructorProfileModel)
    //{
    //    return Ok(await _service.CreateByUserIdAsync(userId, _mapper.Map<CreatingInstructorProfileInfoDto>(instructorProfileModel)));
    //}

    /// <summary>
    /// Изменить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="instructorProfileModel"> Модель редактируемого профиля инструктора. </param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Guid userId, UpdatingInstructorProfileInfoModel instructorProfileModel)
    {
        try
        {
            await _service.UpdateAsync(userId, _mapper.Map<UpdatingInstructorProfileInfoModel, UpdatingInstructorProfileInfoDto>(instructorProfileModel));
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Подтверждение изменений профиля
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="profileStatus"> Статус профиля. </param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPut("confirmСhanges")]
    public async Task<IActionResult> ConfirmСhangesAsync(Guid userId, ProfileStatuses profileStatus)
    {
        try
        {
            await _service.ConfirmСhangesAsync(userId, profileStatus);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удалить профиль инструктора по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор профиля инструктора. </param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid userId)
    {
        try
        {
            await _service.DeleteAsync(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Получить список профилей инструктора.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Страница профилей инструктора. </returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        try
        {
            return Ok(_mapper.Map<List<InstructorProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Получить cписок профилей инструктора требующих подтверждение изменений
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns></returns>
    [HttpGet("listRequiredConfirmation")]
    public async Task<IActionResult> GetRequiredConfirmationAsync(int page, int itemsPerPage)
    {
        try
        {
            return Ok(_mapper.Map<List<InstructorProfileInfoModel>>(await _service.GetRequiredConfirmationAsync(page, itemsPerPage)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
