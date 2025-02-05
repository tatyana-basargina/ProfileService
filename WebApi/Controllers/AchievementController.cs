using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.AchievementContracts;
using WebApi.Models.AchievementModels;
using WebApi.Models.ClientProfileInfoModels;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AchievementController : ControllerBase
{
    private readonly IAchievementServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<AchievementController> _logger;
    public AchievementController(IAchievementServiceApp service, ILogger<AchievementController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<AchievementModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingAchievementModel achievementModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingAchievementDto>(achievementModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingAchievementModel achievementModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingAchievementModel, UpdatingAchievementDto>(achievementModel));
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
        return Ok(_mapper.Map<List<AchievementModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
