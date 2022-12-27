using Microsoft.OpenApi.Models;

namespace WatchDog.Modules.Swagger
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
        public string In { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}