using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WatchDog.Models.Dto;
using WatchDog.Repository;

namespace WatchDog.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class WatchLogController : ControllerBase
    {
        protected ResponseDto _response;
        private IWatchLogsRepository _WatchLogsRepository;

        public WatchLogController(IWatchLogsRepository WatchLogsRepository)
        {
            _WatchLogsRepository = WatchLogsRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<WatchLogsDto> LogDto = await _WatchLogsRepository.GetWatchLogs();
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

        [HttpGet]
        [Route("{method}")]
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
    }
}
