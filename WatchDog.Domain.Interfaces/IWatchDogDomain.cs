using WatchDog.Domain.Entity;


namespace WatchDog.Domain.Interfaces
{
    public interface IWatchDogDomain
    {
        WatchLogs GetWatchLogById(int Id);
    
    }
}
