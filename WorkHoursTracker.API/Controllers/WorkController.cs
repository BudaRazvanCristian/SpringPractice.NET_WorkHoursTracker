using Microsoft.AspNetCore.Mvc;
using WorkHoursTracker.API.Services;
using WorkHoursTracker.API.Models;

namespace WorkHoursTracker.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WorkController : ControllerBase
{
    private readonly IWorkService _service;

    public WorkController(IWorkService service)
    {
        _service = service;
    }

    [HttpPost("start")]
    public IActionResult Start([FromBody] WorkRequest request)
        => Ok(_service.StartWork(request.Username));

    [HttpPost("stop")]
    public IActionResult Stop([FromBody] WorkRequest request)
        => Ok(_service.StopWork(request.Username));

    [HttpGet("today")]
    public IActionResult Today([FromQuery] string username)
        => Ok(_service.GetTodaySummary(username));

    [HttpGet("week")]
    public IActionResult Week([FromQuery] string username)
        => Ok(_service.GetWeekSummary(username));

    [HttpGet("logs")]
    public IActionResult Logs([FromQuery] string username)
        => Ok(_service.GetFullLog(username));
}
