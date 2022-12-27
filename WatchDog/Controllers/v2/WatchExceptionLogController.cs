using Microsoft.AspNetCore.Mvc;
using WatchDog.Models.Dto;
using WatchDog.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WatchDog.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class WatchExceptionLogController : ControllerBase
    {
        protected ResponseDto _response;
        private IExceptionLogsRepository _ExceptionLogsRepository;

        public WatchExceptionLogController(IExceptionLogsRepository ExceptionLogsRepository)
        {
            _ExceptionLogsRepository = ExceptionLogsRepository;
            _response = new ResponseDto();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ExceptionLogsDto> ExcLogDto = await _ExceptionLogsRepository.GetExceptionLog();
                _response.Result = ExcLogDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ExceptionLogsDto ExcLogDto = await _ExceptionLogsRepository.GetExceptionLogsById(id);
                _response.Result = ExcLogDto;
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
                bool isSuccess = await _ExceptionLogsRepository.DeleteExceptionLogs(id);
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
