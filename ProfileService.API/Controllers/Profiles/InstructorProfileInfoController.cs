using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.API.Models.InstructorProfileInfoModels;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;

namespace ProfileService.API.Controllers.Profiles;

[ApiController]
[Route("/api/[controller]")]
public class InstructorProfileInfoController : ControllerBase
{
    private readonly IInstructorProfileInfoServiceApp _service;
    private readonly IMapper _mapper;
    private readonly ILogger<InstructorProfileInfoController> _logger;
    public InstructorProfileInfoController(IInstructorProfileInfoServiceApp service, ILogger<InstructorProfileInfoController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetAsync(Guid id)
    //{
    //    return Ok(_mapper.Map<InstructorProfileInfoModel>(await _service.GetByIdAsync(id)));
    //}

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserIdAsync(Guid userId)
    {
        return Ok(_mapper.Map<InstructorProfileInfoModel>(await _service.GetByUserIdAsync(userId)));
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoModel instructorProfileModel)
    {
        return Ok(await _service.CreateByUserIdAsync(userId, _mapper.Map<CreatingInstructorProfileInfoDto>(instructorProfileModel)));
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> EditAsync(Guid userId, UpdatingInstructorProfileInfoModel instructorProfileModel)
    {
        await _service.UpdateAsync(userId, _mapper.Map<UpdatingInstructorProfileInfoModel, UpdatingInstructorProfileInfoDto>(instructorProfileModel));
        return Ok();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteAsync(Guid userId)
    {
        await _service.DeleteAsync(userId);
        return Ok();
    }

    [HttpGet("list/{page}/{itemsPerPage}")]
    public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
    {
        return Ok(_mapper.Map<List<InstructorProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
