using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using WebApi.Models.ClientProfileInfoModels;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")] 
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ClientProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingClientProfileInfoModel ProfileModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingClientProfileInfoDto>(ProfileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(Guid id, UpdatingClientProfileInfoModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingClientProfileInfoModel, UpdatingClientProfileInfoDto>(ProfileModel));
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
        return Ok(_mapper.Map<List<ClientProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
