using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecurePasswordsDataAccess.Data;
using SecurePasswordsDataAccess.Databases;

namespace SecurePasswords
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            
            IConfiguration configuration = builder.Build();
            services.AddSingleton(configuration);

            services.AddTransient<SerivceModule>();
            services.AddTransient<IDataHandler, DataManager>();
            services.AddTransient<IDataAccess, SqlDataAccess>();

            return services;
        }
    }
}