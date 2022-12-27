using AutoMapper;
using WatchDog.Application.DTO;
using WatchDog.Application.Interface;
using WatchDog.Application.Validator;
using WatchDog.Domain.Interfaces;
using WatchDog.Transversal.Common;


namespace WarchDog.Application.Main
{
    public class WatchDogApplication : IWatchDogApplication
    {
        private readonly IWatchDogDomain _watchDogDomain;
        private readonly IMapper _iMapper;
        private readonly WatchLogsDtoValidators _watchLogsDtoValidators;

        public WatchDogApplication(IWatchDogDomain watchDogDomain, IMapper iMapper, WatchLogsDtoValidators watchLogsDtoValidators)
        {
            _watchDogDomain = watchDogDomain;
            _iMapper = iMapper;
            _watchLogsDtoValidators = watchLogsDtoValidators;
        }

        public ResponseGeneric<List<WatchLogsDto>> GetWatchLogById(int Id)
        {
           
            var response = new ResponseGeneric<List<WatchLogsDto>>();
            var validation = _watchLogsDtoValidators.Validate(new WatchLogsDto() { id = Id });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var WatchLog = _watchDogDomain.GetWatchLogById(Id);
                response.Data = _iMapper.Map<List<WatchLogsDto>>(WatchLog);
                response.IsSuccess = true;
                response.Message = "Validación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Numero no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        } 
    }
}