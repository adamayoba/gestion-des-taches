using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.API.Startup
{
    public static class AuthorizationConfig
    {
        public static IServiceCollection AddAuthorizations(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireUserRole", policy =>
                        policy.RequireRole("User", "Admin")); 

                    options.AddPolicy("RequireAdminRole", policy =>
                        policy.RequireRole("Admin")); 
                });

            return services;
        }
    }
}