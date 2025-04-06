using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    /// Получить профиль
    /// </summary>
    /// <param name="id"> Идентификатор профиля. </param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ProfileInfoModel>(await _service.GetByIdAsync(id)));
    }
    /// <summary>
    /// Создать профиль
    /// </summary>
    /// <param name="userId"> id пользователя. </param>
    /// <param name="profileModel"></param>
    [HttpPost("create/")]
    public async Task<IActionResult> CreateAsync(Guid userId, CreatingProfileInfoModel profileModel)
    {
        return Ok(await _service.CreateAsync(userId, _mapper.Map<CreatingProfileInfoDto>(profileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(Guid id, UpdatingProfileInfoModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingProfileInfoModel, UpdatingProfileInfoDto>(ProfileModel));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("list/{page}/{itemsPerPage}")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        return Ok(_mapper.Map<List<ProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
