﻿using System.Diagnostics;
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
public class TrackersController : ControllerBase
{
    private readonly ITrackersService _service;

    public TrackersController(ITrackersService service)
    {
        _service = service;
    }

    private string GetToken()
    {
        if (Request.Headers.TryGetValue("Authorization", out var token))
        {
            return token;
        }

        throw new AuthenticationException("You are unauthenticated, Token not found!");
    }
    
    private async Task<ActionResult<T>> HandleRequestAsync<T>(Func<Task<T>> func)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await func());
        }
        catch (ElementNotFoundException e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
        catch (InvalidIncomingParameterException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (AuthenticationException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
        }
    }
    
    [HttpGet]
    [Route("getAllTrackers")]
    public Task<ActionResult<List<Tracker>>> GetAllTrackers()
    {
        return HandleRequestAsync(async () => await _service.GetAllTrackersAsync());
    }
    
    
    [HttpPost]
    [Route("trackerHistory")]
    public Task<ActionResult<List<Tracker>>> TrackerHistory([FromBody] TrackerHistoryContract contract)
    {
        return HandleRequestAsync(async () =>
        {
            var token = GetToken();
            return await _service.GetTrackerHistoryAsync(contract, token);
        });
    }
    
    [HttpPost]
    [Route("addCalorieTracker")]
    public Task<ActionResult<Tracker>> AddCalorieTracker([FromBody] CreateCalorieTrackerContract contract)
    {
        return HandleRequestAsync(async () =>
        {
            var token = GetToken();
            return await _service.AddCalorieTrackerAsync(contract, token);
        });
    }
    
    [HttpPost]
    [Route("addActivityTracker")]
    public Task<ActionResult<Tracker>> AddActivityTracker([FromBody] CreateActivityTrackerContract contract)
    {
        return HandleRequestAsync(async () =>
        {
            var token = GetToken();
            return await _service.AddActivityTrackerAsync(contract, token);
        });
    }
    
    [HttpPost]
    [Route("addSleepTracker")]
    public Task<ActionResult<Tracker>> AddSleepTracker([FromBody] CreateSleepTrackerContract contract)
    {
        return HandleRequestAsync(async () =>
        {
            var token = GetToken();
            return await _service.AddSleepTrackerAsync(contract, token);
        });
    }
    
    [HttpPut]
    [Route("updateSleepQuality")]
    public Task<ActionResult<Tracker>> UpdateSleepQuality([FromBody] UpdateSleepTrackerContract contract)
    {
        return HandleRequestAsync(async () => await _service.UpdateSleepQualityAsync(contract));
    }
    
    [HttpDelete]
    [Route("deleteTracker")]
    public Task<ActionResult<Tracker>> DeleteTracker(Guid id)
    {
        return HandleRequestAsync(async () => await _service.DeleteTrackerAsync(id));
    }
}