using AutoMapper;
using WatchDog.Application.DTO;
using WatchDog.Application.Interface;
using WatchDog.Application.Validator;
using WatchDog.Domain.Interfaces;
using WatchDog.Transversal.Common;

namespace WarchDog.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, UsersDtoValidator usersDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _usersDtoValidator = usersDtoValidator;
        }

        

        public ResponseGeneric<UsersDto> Authenticate(string username, string password)
        {
            var response = new ResponseGeneric<UsersDto>();
            var validation = _usersDtoValidator.Validate(new UsersDto() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
