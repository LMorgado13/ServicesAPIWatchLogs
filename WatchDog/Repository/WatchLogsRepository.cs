using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WatchDog.Application.Validator;
using WatchDog.DbContexts;
using WatchDog.Models;
using WatchDog.Models.Dto;
using WatchDog.Transversal.Common;


namespace WatchDog.Repository
{
    public class WatchLogsRepository : IWatchLogsRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        private readonly WatchLogsDtoValidators _watchLogsDtoValidators;

        public WatchLogsRepository(ApplicationDbContext db, IMapper mapper, WatchLogsDtoValidators watchLogsDtoValidators)
        {
            _db = db;
            _mapper = mapper;
            _watchLogsDtoValidators = watchLogsDtoValidators;
        }

        public async Task<bool> DeleteWatchLogs(int id)
        {
            
            try
            {
                WatchDog_WatchLogs DelWatchLog = await _db.WatchDog_WatchLog.FirstOrDefaultAsync(u => u.id == id);
                if (DelWatchLog == null)
                {
                    return false;
                }
                _db.WatchDog_WatchLog.Remove(DelWatchLog);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteWatchLogs()
        {
            try
            {
                List<WatchDog_WatchLogs> DelWatchLog = await _db.WatchDog_WatchLog.ToListAsync();
                if (DelWatchLog == null)
                {
                    return false;
                }
                _db.WatchDog_WatchLog.RemoveRange(DelWatchLog);
                //return _mapper.Map<List<WatchLogsDto>>(DelWatchLog);
                await _db.SaveChangesAsync();
                return true;
                
            }
            catch (Exception)
            {
                return false;

            }
            
        }

        public async Task<IEnumerable<WatchLogsDto>> GetWatchLogs()
        {
            List<WatchDog_WatchLogs> ExceptionLog = await _db.WatchDog_WatchLog.ToListAsync();
            return _mapper.Map<List<WatchLogsDto>>(ExceptionLog);
        }

        public async Task<IEnumerable<WatchLogsDto>> GetWatchLogsById(string Method, int respEst)
        {
            //if (string.IsNullOrWhiteSpace(Method) && string.IsNullOrWhiteSpace(Convert.ToString(respEst))) { return NotFound; }
            if (respEst == 0)
            {
                List<WatchDog_WatchLogs> ExceptionLogsById = await _db.WatchDog_WatchLog
                .Where(x => x.method == Method)
                .OrderBy(x => x.endTime)
                .ToListAsync();
                return _mapper.Map<List<WatchLogsDto>>(ExceptionLogsById);
            }
            else if (!string.IsNullOrWhiteSpace(Method)  && respEst > 0 )
            {
                List<WatchDog_WatchLogs> ExceptionLogsById = await _db.WatchDog_WatchLog
               .Where(x => x.method == Method && x.responseStatus == respEst)
               .OrderBy(x => x.endTime)
               .ToListAsync();
                return _mapper.Map<List<WatchLogsDto>>(ExceptionLogsById);
            }
            else if (Method == "ALL" && respEst > 0)
            {
                List<WatchDog_WatchLogs> ExceptionLogsById = await _db.WatchDog_WatchLog
                .Where(x => x.responseStatus == respEst)
                .OrderBy(x => x.endTime)
                .ToListAsync();
                return _mapper.Map<List<WatchLogsDto>>(ExceptionLogsById);
            }
            else {
                List<WatchDog_WatchLogs> ExceptionLogsById = await _db.WatchDog_WatchLog
                .Where(x => x.responseStatus == respEst)
                .OrderBy(x => x.endTime)
                .ToListAsync();
                return _mapper.Map<List<WatchLogsDto>>(ExceptionLogsById);
            }
               
            
        }

        public async Task<ResponseGeneric<List<WatchLogsDto>>> GetWatchLogById(int Id)
        {
            //List<WatchDog_WatchLogs> getLogsById = await _db.WatchDog_WatchLog.Where(x => x.id == Id).ToListAsync();
            ////var response = 
            //return _mapper.Map< ResponseGeneric<List<WatchLogsDto>>>(getLogsById);

            var response = new ResponseGeneric<List<WatchLogsDto>>();
           
            try
            {
                var customer = await _db.WatchDog_WatchLog.Where(x => x.id == Id).ToListAsync();
                response.Data = _mapper.Map< List<WatchLogsDto>>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        public async Task<IEnumerable<WatchLogsDto>> GetWatchLogsByPath(string Patch)
        {
            List<WatchDog_WatchLogs> WatchLogstrPATH = await _db.WatchDog_WatchLog.Where(x => x.path == Patch).ToListAsync();
            return _mapper.Map<List<WatchLogsDto>>(WatchLogstrPATH);
        }

        public async Task<List<WatchLogsHttpDto>> GetWatchLogsHttps()
        {
            List<WatchDog_Https> ExceptionLog = await _db.WatchDog_Https.ToListAsync();
            return _mapper.Map<List<WatchLogsHttpDto>>(ExceptionLog);
        }

        public async Task<List<WatchDogStatusDto>> GetWatchLogsStatus()
        {
            List<WatchDog_Status> ExceptionLog = await _db.WatchDog_Status.ToListAsync();
            return _mapper.Map<List<WatchDogStatusDto>>(ExceptionLog);
        }
    }
}
