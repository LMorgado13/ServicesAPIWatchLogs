using WatchDog.Models.Dto;
using WatchDog.Transversal.Common;

namespace WatchDog.Repository
{
    public interface IWatchLogsRepository
    {
        Task<IEnumerable<WatchLogsDto>> GetWatchLogs();
        Task<IEnumerable<WatchLogsDto>> GetWatchLogsById(string method, int respEst);
        Task<IEnumerable<WatchLogsDto>> GetWatchLogsByPath(string Patch);
        Task<ResponseGeneric<List<WatchLogsDto>>> GetWatchLogById(int Id);
        Task<List<WatchLogsHttpDto>> GetWatchLogsHttps();
        Task<List<WatchDogStatusDto>> GetWatchLogsStatus();
        Task<bool> DeleteWatchLogs(int id);
        Task<bool> DeleteWatchLogs();
    }
}
