using System.Diagnostics;
using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MishFit.Contracts;
using MishFit.Entities;
using MishFit.Exceptions;
using MishFit.Repositories;
using MishFit.Services;

namespace MishFit.Controllers;

[ApiController]
[Route(("/api/v1/[controller]"))]
public class TrackerController : ControllerBase
{
    private readonly ITrackerRepository _repository;

    public TrackerController(ITrackerRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("TrackerHistory")]
    public async Task<ActionResult<List<Tracker>>> TrackerHistory(TrackerHistoryContract contract)
    {
        try
        {
            if (Request.Headers.TryGetValue("Authorization", out var token))
            {
                return StatusCode(StatusCodes.Status200OK, await _repository.GetTrackerHistory(contract, token));
            }
        }
        catch (InvalidIncomingParameterException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }


        return StatusCode(StatusCodes.Status401Unauthorized, "You are unauthenticated, Token not found!");
    }
    
}