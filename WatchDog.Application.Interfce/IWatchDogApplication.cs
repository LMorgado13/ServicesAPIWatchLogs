using WatchDog.Application.DTO;
using WatchDog.Transversal.Common;

namespace WatchDog.Application.Interface
{
    public interface IWatchDogApplication
    {
        ResponseGeneric<List<WatchLogsDto>> GetWatchLogById(int Id);
    }
}
