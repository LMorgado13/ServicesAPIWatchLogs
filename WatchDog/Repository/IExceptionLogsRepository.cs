using WatchDog.Models.Dto;

namespace WatchDog.Repository
{
    public interface IExceptionLogsRepository
    {
        Task<IEnumerable<ExceptionLogsDto>> GetExceptionLog();
        Task<ExceptionLogsDto> GetExceptionLogsById(int id);
        Task<bool> DeleteExceptionLogs(int id);
    }
}
