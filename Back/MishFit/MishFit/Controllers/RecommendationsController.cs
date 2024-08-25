using Microsoft.AspNetCore.Mvc;
using MishFit.Enums;
using MishFit.Exceptions;
using MishFit.Responses;
using MishFit.Services;

namespace MishFit.Controllers;

[ApiController]
[Route(("/api/v1/[controller]"))]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationsService _service;

    public RecommendationsController(IRecommendationsService service)
    {
        _service = service;
    }

    [HttpGet("random")]
    public async Task<ActionResult<RecommendationResponse>> Random(RecommendationType recommendationType)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _service.RandomRecommendation(recommendationType));
        }
        catch (InvalidIncomingParameterException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
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
}