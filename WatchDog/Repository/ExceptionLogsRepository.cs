using AutoMapper;
using WatchDog.DbContexts;
using WatchDog.Models;
using WatchDog.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace WatchDog.Repository
{
    public class ExceptionLogsRepository : IExceptionLogsRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ExceptionLogsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> DeleteExceptionLogs(int Id)
        {
            try
            {
                WatchDog_WatchExceptionLogs ExceptionLogs = await _db.WatchDog_WatchExceptionLog.FirstOrDefaultAsync(u => u.id == Id);
                if (ExceptionLogs == null)
                {
                    return false;
                }
                _db.WatchDog_WatchExceptionLog.Remove(ExceptionLogs);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public async Task<ExceptionLogsDto> GetExceptionLogsById(int Id)
        {
            WatchDog_WatchExceptionLogs ExceptionLogsById = await _db.WatchDog_WatchExceptionLog.Where(x => x.id == Id).FirstOrDefaultAsync();
            return _mapper.Map<ExceptionLogsDto>(ExceptionLogsById);
        }

        public async Task<IEnumerable<ExceptionLogsDto>> GetExceptionLog()
        {
            List<WatchDog_WatchExceptionLogs> ExceptionLog = await _db.WatchDog_WatchExceptionLog.ToListAsync();
            return _mapper.Map<List<ExceptionLogsDto>>(ExceptionLog);
        }
    }
}
