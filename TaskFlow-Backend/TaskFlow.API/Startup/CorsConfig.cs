using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.API.Startup
{
    public static class CorsConfig
    {
        private const string AllowAllPolicy = "AllowAll";
        public static void AddCorsService(this IServiceCollection service)
        {
            service.AddCors(options => 
            {
                options.AddPolicy(AllowAllPolicy,
                    policy =>
                    {
                        policy.AllowAnyOrigin() 
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public static void ApplyCorsConfig(this WebApplication app)
        {
            app.UseCors(AllowAllPolicy);
        }
    }
}