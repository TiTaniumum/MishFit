using Microsoft.AspNetCore.Mvc;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Services;

namespace MishFit.Controllers;


[ApiController]
[Route(("/api/v1/[controller]"))]
public class ActivitiesController: ControllerBase
{
    private readonly IActivitiesService _service;
    
    public ActivitiesController(IActivitiesService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetAllActivitiesAsync()
    {
        return await _service.GetAllActivitiesAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityByIdAsync(Guid id)
    {
        return await _service.GetActivityByIdAsync(id);
    }

    [HttpPost]
    [Route("createActivity")]
    public async Task<ActionResult<Activity>> CreateActivityAsync([FromBody] CreateActivityContract contract)
    {
        return await _service.CreateActivityAsync(contract);
    }

    [HttpPost]
    [Route("updateActivity")]
    public async Task<ActionResult<Activity>> UpdateActivityAsync([FromBody] UpdateActivityContract contract)
    {
        return await _service.UpdateActivityAsync(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Activity>> DeleteActivityByIdAsync(Guid id)
    {
        return await _service.DeleteActivityByIdAsync(id);
    }
}