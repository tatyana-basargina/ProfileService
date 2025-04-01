using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.LevelTrainingModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.LevelTrainingContracts;

namespace ProfileService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelTrainingController : ControllerBase
{
    private readonly ILevelTrainingServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<LevelTrainingController> _logger;
    public LevelTrainingController(ILevelTrainingServiceApp service, ILogger<LevelTrainingController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<LevelTrainingModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingLevelTrainingModel ProfileModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingLevelTrainingDto>(ProfileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingLevelTrainingModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingLevelTrainingModel, UpdatingLevelTrainingDto>(ProfileModel));
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
        return Ok(_mapper.Map<List<LevelTrainingModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
