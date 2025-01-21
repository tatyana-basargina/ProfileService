using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts;
using ProfileService.Models.Profile;

namespace ProfileService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfileController> _logger;
    public ProfileController(IProfileServiceApp service, ILogger<ProfileController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<ProfileModel>(await _service.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingProfileModel ProfileModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingProfileDto>(ProfileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(Guid id, UpdatingProfileModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingProfileModel, UpdatingProfileDto>(ProfileModel));
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
        return Ok(_mapper.Map<List<ProfileModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
