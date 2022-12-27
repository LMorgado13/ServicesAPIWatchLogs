using AutoMapper;
using WatchDog.Application.DTO;
using WatchDog.Domain.Entity;
using WatchDog.Models;
using WatchDog.Models.Dto;
using WatchLogsDto = WatchDog.Models.Dto.WatchLogsDto;
//using WatchLogsDto = WatchDog.Application.DTO.WatchLogsDto;


namespace WatchDog
{
    public class MappingConfig: Profile
    {

      
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LogDto, WatchDog_Log>(); 
                config.CreateMap<WatchDog_Log, LogDto>();
                config.CreateMap<ExceptionLogsDto, WatchDog_WatchExceptionLogs>(); 
                config.CreateMap<WatchDog_WatchExceptionLogs, ExceptionLogsDto>();
                config.CreateMap<WatchLogsDto, WatchDog_WatchLogs>();
                config.CreateMap<WatchDog_WatchLogs, WatchLogsDto>();
                config.CreateMap<WatchLogsDto, WatchLogs>();
                config.CreateMap<WatchLogs, WatchLogsDto>();
                config.CreateMap<WatchDog_Https, WatchLogsHttpDto>();
                config.CreateMap<WatchLogsHttpDto, WatchDog_Https>();
                config.CreateMap<WatchDogStatusDto, WatchDog_Status>();
                config.CreateMap<WatchDog_Status, WatchDogStatusDto>();
                config.CreateMap<UsersDto, Users>();
                config.CreateMap<Users, UsersDto>();

            });

            return mappingConfig;
        }
    }
}
