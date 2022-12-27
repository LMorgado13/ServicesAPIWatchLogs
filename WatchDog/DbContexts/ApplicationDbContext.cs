using Microsoft.EntityFrameworkCore;
using WatchDog.Domain.Entity;
using WatchDog.Models;

namespace WatchDog.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
     
            public DbSet<WatchDog_Log> WatchDog_Logs { get; set; }
            public DbSet<WatchDog_WatchExceptionLogs> WatchDog_WatchExceptionLog { get; set; }
            public DbSet<WatchDog_WatchLogs> WatchDog_WatchLog { get; set; }
            public DbSet<WatchDog_Https> WatchDog_Https { get; set; }
            public DbSet<WatchDog_Status> WatchDog_Status { get; set; }
            public DbSet<Users> User { get; set; }


    }
}
