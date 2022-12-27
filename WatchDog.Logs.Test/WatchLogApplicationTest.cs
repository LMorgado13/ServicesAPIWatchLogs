using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MorganLogs.Services.WatchDogAPI;
using WatchDog.Application.Interface;

namespace WatchDog.Logs.Test
{
    [TestClass]
    public class WatchLogApplicationTest
    {

        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.AddLogging().BuildServiceProvider().GetService<IServiceScopeFactory>();
            //_scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void GetWatchLogsById_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IWatchDogApplication>();

            // Arrange
            int Id = 0;
            var expected = "Errores de Validación";

            // Act            
            var result = context.GetWatchLogById(Id);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetWatchLogsById_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IWatchDogApplication>();

            // Arrange
            Int32 Id = 17126;
            var expected = "Validación Exitosa!!!";

            // Act
            var result = context.GetWatchLogById(Id);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void GetWatchLogsById_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        //{
        //    using var scope = _scopeFactory.CreateScope();
        //    var context = scope.ServiceProvider.GetService<IWatchDogApplication>();

        //    // Arrange
        //    int Id = 1126;
        //    var expected = "Numero no existe";

        //    // Act
        //    var result = context.GetWatchLogById(Id);
        //    var actual = result.Message;

        //    // Assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}