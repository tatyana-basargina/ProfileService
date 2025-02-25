using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using WebApi.Models.InstructorProfileInfoModels;

namespace WebApi.Controllers.Profiles;

[ApiController]
[Route("{userId}/[controller]")]
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(_mapper.Map<InstructorProfileInfoModel>(await _service.GetByIdAsync(id)));
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateAsync(CreatingInstructorProfileInfoModel instructorProfileModel)
    //{
    //    return Ok(await _service.CreateAsync(_mapper.Map<CreatingInstructorProfileInfoDto>(instructorProfileModel)));
    //}

    [HttpPost]
    //[Route("{userId}/[controller]")]
    public async Task<IActionResult> CreateByUserIdAsync(Guid userId, CreatingInstructorProfileInfoModel instructorProfileModel)
    {
        return Ok(await _service.CreateByUserIdAsync(userId, _mapper.Map<CreatingInstructorProfileInfoDto>(instructorProfileModel)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAsync(Guid id, UpdatingInstructorProfileInfoModel ProfileModel)
    {
        await _service.UpdateAsync(id, _mapper.Map<UpdatingInstructorProfileInfoModel, UpdatingInstructorProfileInfoDto>(ProfileModel));
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
        return Ok(_mapper.Map<List<InstructorProfileInfoModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
    }
}
