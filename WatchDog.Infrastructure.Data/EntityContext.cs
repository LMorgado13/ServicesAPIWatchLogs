using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WatchDog.Infrastructure.Data
{
    public class EntityContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public EntityContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}