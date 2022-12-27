using WatchDog.Models.Dto;

namespace WatchDog.Repository
{
    public interface ILogRepository
    {
        Task<IEnumerable<LogDto>> GetLog();
        Task<LogDto> GetLogsById(int id);
        Task<bool> DeleteLogs(int id);
    }
}
