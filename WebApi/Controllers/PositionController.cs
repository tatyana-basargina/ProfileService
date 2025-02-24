using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.PositionContracts;
using WebApi.Models.PositionModels;

namespace ProfileService.Controllers;

[ApiController]
[Route("[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<PositionController> _logger;
    public PositionController(IPositionServiceApp service, ILogger<PositionController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<PositionModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingPositionModel ProfileModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingPositionDto>(ProfileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingPositionModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingPositionModel, UpdatingPositionDto>(ProfileModel));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("list/{page}/{itemsPerPage}")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        return Ok(_mapper.Map<List<PositionModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
