using Microsoft.AspNetCore.Mvc;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Repositories;
using MishFit.Services;

namespace MishFit.Controllers;

[ApiController]
[Route(("/api/v1/[controller]"))]
public class MealsController: ControllerBase
{
    private readonly IMealsService _service;
    
    public MealsController(IMealsService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Meal>>> GetAllMealsAsync()
    {
        return await _service.GetAllMealsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetMealByIdAsync(Guid id)
    {
        return await _service.GetMealByIdAsync(id);
    }

    [HttpPost]
    [Route("createMeal")]
    public async Task<ActionResult<Meal>> CreateMealAsync([FromBody] CreateMealContract contract)
    {
        return await _service.CreateMealAsync(contract);
    }

    [HttpPost]
    [Route("updateMeal")]
    public async Task<ActionResult<Meal>> UpdateMealAsync([FromBody] UpdateMealContract contract)
    {
        return await _service.UpdateMealAsync(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Meal>> DeleteMealByIdAsync(Guid id)
    {
        return await _service.DeleteMealByIdAsync(id);
    }

}