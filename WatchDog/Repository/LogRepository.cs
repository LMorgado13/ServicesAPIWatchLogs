using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchDog.DbContexts;
using WatchDog.Models;
using WatchDog.Models.Dto;

namespace WatchDog.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public LogRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> DeleteLogs(int Id)
        {
            try
            {
                WatchDog_Log Logs = await _db.WatchDog_Logs.FirstOrDefaultAsync(u => u.id == Id);
                if (Logs == null)
                {
                    return false;
                }
                _db.WatchDog_Logs.Remove(Logs);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<LogDto>> GetLog()
        {
            List<WatchDog_Log> strLog = await _db.WatchDog_Logs.ToListAsync();
            return _mapper.Map<List<LogDto>>(strLog);
        }

        public async Task<LogDto> GetLogsById(int Id)
        {
            WatchDog_Log strnLogsById = await _db.WatchDog_Logs.Where(x => x.id == Id).FirstOrDefaultAsync();
            return _mapper.Map<LogDto>(strnLogsById);
        }
    }
}
