
using System.Collections.Generic;
using WatchDog.Domain.Entity;
using WatchDog.Domain.Interfaces;

namespace WatchDog.Domain.Cors
{
    public class WatchDogDomain : IWatchDogDomain
    {
       
        public WatchLogs GetWatchLogById(int Id)
        {
            return  GetWatchLogById(Id);
        }
    }
}