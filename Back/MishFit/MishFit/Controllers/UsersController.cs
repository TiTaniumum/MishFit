using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Services;

namespace MishFit.Controllers;

[ApiController]
[Route(("/api/v1/[controller]"))]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;

    public UsersController(IUsersService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<User>>> GetAllUsersAsync()
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllUsersAsync());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserByIdAsync(Guid id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetUserByIdAsync(id));
        }
        catch (InvalidIncomingParameterException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (ElementAlreadyExistsException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    [HttpGet]
    [Route("getUserByToken/{token}")]
    public async Task<ActionResult<User>> GetUserByTokenAsync(string token)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetUserByTokenAsync("Bearer "+token));
        }
        catch (InvalidIncomingParameterException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (ElementAlreadyExistsException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<User>> UpdateUserAsync([FromBody] UpdateUserContract contract)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid model state");

        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.UpdateUserAsync(contract));
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
        catch (ElementAlreadyExistsException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserByIdAsync(Guid id)
    {
        try
        {
            await _service.DeleteUserByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK);
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
    

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> RegisterUserAsync([FromBody] RegisterUserContract contract)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid model state");
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _service.RegisterUserAsync(contract));
        }
        
        catch (ElementAlreadyExistsException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenResponse>> LoginUserAsync([FromBody] LoginUserContract contract)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid model state");
        try
        {
            var token = await _service.LoginUserAsync(contract);
            return StatusCode(StatusCodes.Status200OK, token);
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
        catch (AuthenticationFailedException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
}