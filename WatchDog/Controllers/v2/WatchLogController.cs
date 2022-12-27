using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WatchDog.DbContexts;
using WatchDog.Models.Dto;
using WatchDog.Repository;
using WatchDog.Transversal.Common;
using WatchDog.Utilidades;

namespace WatchDog.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class WatchLogController : ControllerBase
    {
        protected ResponseDto _response;
        private IWatchLogsRepository _WatchLogsRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WatchLogController(IWatchLogsRepository WatchLogsRepository, ApplicationDbContext context, IMapper mapper)
        {
            _WatchLogsRepository = WatchLogsRepository;
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        //[HttpGet]
        //public async Task<object> Get()
        //{
        //    try
        //    {
        //        IEnumerable<WatchLogsDto> LogDto = await _WatchLogsRepository.GetWatchLogs();
        //        _response.Result = LogDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages
        //             = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        [HttpGet("GetLogsHttps")]
      
        public async Task<object> GetLogsHttps()
        {
            try
            {
                List<WatchLogsHttpDto> LogHttpDto = await _WatchLogsRepository.GetWatchLogsHttps();
                _response.Result = LogHttpDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("GetLogsStatus")]

        public async Task<object> GetLogsStatus()
        {
            try
            {
                List<WatchDogStatusDto> LogHttpDto = await _WatchLogsRepository.GetWatchLogsStatus();
                _response.Result = LogHttpDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                //WatchLogsDto ExcLogDto = await _WatchLogsRepository.GetWatchLogsById(id); 
                //List<WatchLogsDto> ExcLogDto = await _WatchLogsRepository.GetWatchLogById(id);
                var response = await _WatchLogsRepository.GetWatchLogById(id);
                if (response.IsSuccess)
                {
                    response.IsSuccess = true;
                }
                    _response.Result = response.Data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<WatchLogsDto>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = _context.WatchDog_WatchLog.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var WatchLogs = await queryable.OrderBy(x => x.id).Paginar(paginacionDTO).ToListAsync();
            return _mapper.Map<List<WatchLogsDto>>(WatchLogs);
        }

        [HttpGet]
        [Route("{method}/{respEst}")]
        public async Task<object> Get(string method, int respEst)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(method) && string.IsNullOrWhiteSpace(Convert.ToString(respEst))) { return new List<object>(); }
                IEnumerable<WatchLogsDto> LogDto = await _WatchLogsRepository.GetWatchLogsById(method, respEst);
                _response.Result = LogDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> buscarPath([FromBody] string Patch)
        {
            try
            {
                IEnumerable<WatchLogsDto> LogDto = await _WatchLogsRepository.GetWatchLogsByPath(Patch);
                _response.Result = LogDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _WatchLogsRepository.DeleteWatchLogs(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete()
        {
            try
            {
                bool isSuccess = await _WatchLogsRepository.DeleteWatchLogs();
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
