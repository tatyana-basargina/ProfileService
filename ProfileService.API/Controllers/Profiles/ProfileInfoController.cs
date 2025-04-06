using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.PositionModels;
using ProfileService.API.Models.ProfileInfoModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ProfileInfoContracts;

namespace ProfileService.API.Controllers.Profiles;

[ApiController]
[EnableCors("AllowReactApp")]
[Route("/api/[controller]")]
public class ProfileInfoController : ControllerBase
{
    private readonly IProfileInfoServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfileInfoController> _logger;
    public ProfileInfoController(IProfileInfoServiceApp service, ILogger<ProfileInfoController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    /// <summary>
    /// Получить профиль пользователя.
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя. </param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId)
    {
        return Ok(_mapper.Map<ProfileInfoModel>(await _service.GetByUserIdAsync(userId)));
    }

    ///// <summary>
    ///// Создать профиль пользователя.
    ///// </summary>
    ///// <param name="userId"> Идентификатор пользователя. </param>
    ///// <param name="profileModel"> Модель создаваемого профиля. </param>
    //[HttpPost("create")]
    //public async Task<IActionResult> CreateAsync(Guid userId, CreatingProfileInfoModel profileModel)
    //{
    //    return Ok(await _service.CreateAsync(userId, _mapper.Map<CreatingProfileInfoDto>(profileModel)));
    //}

    /// <summary>
    /// Изменить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    /// <param name="ProfileModel"> Модель редактируемого профиля. </param>
    /// <returns></returns>
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdatingProfileInfoModel ProfileModel)
    {
        try
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingProfileInfoModel, UpdatingProfileInfoDto>(ProfileModel));
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удалить профиль.
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    /// <returns></returns>
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Получить постраничный список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns></returns>
    [HttpGet("list")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        try
        {
            return Ok(_mapper.Map<List<ProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
