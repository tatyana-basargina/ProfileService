using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ProfileInfoContracts;
using WebApi.Models.ProfileInfoModels;

namespace ProfileService.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingProfileInfoModel ProfileModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingProfileInfoDto>(ProfileModel)));
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
