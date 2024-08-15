using Microsoft.AspNetCore.Mvc;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Services;

namespace MishFit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodsService _service;

    public FoodsController(IFoodsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Food>>> GetAllFoodsAsync()
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllFoodsAsync());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Food>> GetFoodByIdAsync(Guid id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetFoodByIdAsync(id));
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Food>> CreateFoodAsync([FromBody] CreateFoodContract contract)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid model state");

        try
        {
            return StatusCode(StatusCodes.Status201Created, await _service.CreateFoodAsync(contract));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<Food>> UpdateFoodAsync([FromBody] UpdateFoodContract contract)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid model state");

        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.UpdateFoodAsync(contract));
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFoodByIdAsync(Guid id)
    {
        try
        {
            await _service.DeleteFoodByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
}