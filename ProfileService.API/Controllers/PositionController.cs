using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.PositionModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.PositionContracts;

namespace ProfileService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionServiceApp _service;
    private readonly IMapper _mapper;
    public PositionController(IPositionServiceApp service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<PositionModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingPositionModel positionModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingPositionDto>(positionModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingPositionModel positionModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingPositionModel, UpdatingPositionDto>(positionModel));
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
