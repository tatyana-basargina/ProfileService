using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.AchievementModels;
using ProfileService.API.Models.FileAchievementModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.AchievementContracts;
using ProfileService.Application.Contracts.FileAchievementContracts;

namespace ProfileService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AchievementController : ControllerBase
{
    private readonly IAchievementServiceApp _achievementService;
    private readonly IFileAchievementServiceApp _fileAchievementService;
    private readonly IMapper _mapper;
    private readonly ILogger<AchievementController> _logger;
    public AchievementController(
        IAchievementServiceApp achievementService,
        IFileAchievementServiceApp fileAchievementService,
        ILogger<AchievementController> logger,
        IMapper mapper
    )
    {
        _achievementService = achievementService;
        _fileAchievementService = fileAchievementService;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить достижение
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Достижение</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<AchievementModel>(await _achievementService.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingAchievementModel achievementModel)
    {
        return Ok(await _achievementService.CreateWithFilesAsync(_mapper.Map<CreatingAchievementWithFilesDto>(achievementModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(int id, UpdatingAchievementModel achievementModel)
    {
        await _achievementService.UpdateAsync(id, _mapper.Map<UpdatingAchievementModel, UpdatingAchievementDto>(achievementModel));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _achievementService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("list/{page}/{itemsPerPage}")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        return Ok(_mapper.Map<List<AchievementModel>>(await _achievementService.GetPagedAsync(page, itemsPerPage)));
    }

    [HttpGet("{id}/files")]
    public async Task<IActionResult> GetFileAsync(int id)
    {
        return Ok(_mapper.Map<IEnumerable<FileAchievementModel>>(await _fileAchievementService.GetByAchievementIdAsync(id)));
    }

    [HttpPost("{id}/add-file")]
    public async Task<IActionResult> CreateFileAsync(CreatingFileAchievementModel achievementModel)
    {
        return Ok(await _fileAchievementService.CreateAsync(_mapper.Map<CreatingFileAchievementDto>(achievementModel)));
    }

    [HttpDelete("remove-file/{fileId}")]
    public async Task<IActionResult> DeleteFileAsync(int fileId)
    {
        await _fileAchievementService.DeleteAsync(fileId);
        return Ok();
    }
}
