using ColledgeShedule_Moldovanov.Data;
using ColledgeShedule_Moldovanov.DTO;
using ColledgeShedule_Moldovanov.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColledgeShedule_Moldovanov.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        private readonly AppDbContext _db;

        public ScheduleController(IScheduleService service, AppDbContext db)
        {
            _service = service;
            _db = db;
        }

        [HttpGet("group/{groupName}")]
        public async Task<ActionResult<List<ScheduleByDateDto>>> GetSchedule(
            string groupName,
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            var result = await _service.GetScheduleForGroup(groupName, start, end);
            return Ok(result);
        }

        [HttpGet("groups")]
        public async Task<ActionResult<List<string>>> GetGroups()
        {
            var groups = await _db.StudentGroups
                .OrderBy(g => g.GroupName)
                .Select(g => g.GroupName)
                .ToListAsync();
            return Ok(groups);
        }
    }
}