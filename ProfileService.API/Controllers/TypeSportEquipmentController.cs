using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.TypeSportEquipmentModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.TypeSportEquipmentContracts;

namespace ProfileService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeSportEquipmentController : ControllerBase
{
    private readonly ITypeSportEquipmentServiceApp _service;
    private readonly IMapper _mapper;
    public TypeSportEquipmentController(ITypeSportEquipmentServiceApp service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<TypeSportEquipmentModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingTypeSportEquipmentModel typeSportEquipmentModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingTypeSportEquipmentDto>(typeSportEquipmentModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingTypeSportEquipmentModel typeSportEquipmentModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingTypeSportEquipmentModel, UpdatingTypeSportEquipmentDto>(typeSportEquipmentModel));
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
        return Ok(_mapper.Map<List<TypeSportEquipmentModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
