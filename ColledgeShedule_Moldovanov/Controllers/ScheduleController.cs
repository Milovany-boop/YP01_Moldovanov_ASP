using ColledgeShedule_Moldovanov.DTO;
using ColledgeShedule_Moldovanov.Services;
using Microsoft.AspNetCore.Mvc;

namespace ColledgeShedule_Moldovanov.Controllers
{ 
[ApiController]
[Route("api/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;
    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("group/{groupName}")]
    public async Task<ActionResult<List<ScheduleByDateDto>>> GetSchedule(
        string groupName,
        [FromQuery] DateTime start,
        [FromQuery] DateTime end)
    {
        var result = await _scheduleService.GetScheduleForGroup(groupName, start, end);
        return Ok(result);
    }
}
}
