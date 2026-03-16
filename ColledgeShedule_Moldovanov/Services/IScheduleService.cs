using ColledgeShedule_Moldovanov.DTO;

namespace ColledgeShedule_Moldovanov.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleByDateDto>> GetScheduleForGroup(string groupName, DateTime
startDate, DateTime endDate);
    }
}