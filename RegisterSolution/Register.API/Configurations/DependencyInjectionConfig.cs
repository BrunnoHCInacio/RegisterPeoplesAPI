using System;
using Microsoft.Extensions.DependencyInjection;
using Register.API.Context;
using Register.API.Interfaces;
using Register.API.Notifications;
using Register.API.Repositories;

namespace Register.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase());
            services.AddScoped<AppDbContext>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<INotifier, Notifier>();
            return services;
        }
        
    }
}
