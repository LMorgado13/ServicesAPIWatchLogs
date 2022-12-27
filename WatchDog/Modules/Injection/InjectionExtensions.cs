using WatchDog.Repository;

namespace WatchDog.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            //services.AddScoped<ILogRepository, LogRepository>();
            //services.AddScoped<IExceptionLogsRepository, ExceptionLogsRepository>();
            //services.AddScoped<IWatchLogsRepository, WatchLogsRepository>();

            return services;
        }
    }
}
