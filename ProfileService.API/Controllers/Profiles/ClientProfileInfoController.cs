using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.ClientProfileInfoModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;

namespace ProfileService.API.Controllers.Profiles;

[ApiController]
[EnableCors("AllowReactApp")]
[Route("/api/[controller]")]
public class ClientProfileInfoController : ControllerBase
{
    private readonly IClientProfileInfoServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<ClientProfileInfoController> _logger;
    public ClientProfileInfoController(IClientProfileInfoServiceApp service, ILogger<ClientProfileInfoController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить профиль клиента.
    /// </summary>
    /// <param name="id"> Идентификатор профиля клиента. </param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ClientProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    /// <summary>
    /// Получить профиль клиента по id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId)
    {
        return Ok(_mapper.Map<ClientProfileInfoModel>(await _service.GetByUserIdAsync(userId)));
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateAsync(Guid userId, CreatingClientProfileInfoModel clientProfileModel)
    //{
    //    //
    //    return Ok(await _service.CreateAsync(userId, _mapper.Map<CreatingClientProfileInfoDto>(clientProfileModel)));
    //}

    //[HttpPost("createWithOwner")]
    //public async Task<IActionResult> CreateChildClientProfileInfoAsync(Guid userId, Guid ownerId, CreatingClientProfileInfoModel clientProfileModel)
    //{
    //    return Ok(await _service.CreateWithOwnerAsync(userId, ownerId, _mapper.Map<CreatingClientProfileInfoDto>(clientProfileModel)));
    //}

    /// <summary>
    /// Изменить профиль клиента по Id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <param name="profileModel"> Модель редактируемого профиля клиента. </param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Guid userId, UpdatingClientProfileInfoModel profileModel)
    {
        try
        {
            await _service.UpdateAsync(userId, _mapper.Map<UpdatingClientProfileInfoModel, UpdatingClientProfileInfoDto>(profileModel));
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удалить профиль клиента по Id пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
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
    /// Получить список профилей клиентов.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns></returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        try
        {
            return Ok(_mapper.Map<List<ClientProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
