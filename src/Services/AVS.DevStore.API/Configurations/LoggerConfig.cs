using AVS.DevStore.API.Extensions;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace AVS.DevStore.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Failed when trying to connect to the database.");

            services.AddElmahIo(o =>
            {
                o.ApiKey = builder.Configuration["ElmahIo:ApiKey"]; 
                o.LogId = new Guid(builder.Configuration["ElmahIo:LogId"]);
            });            

            builder.Logging.ClearProviders();
            builder.Logging.AddElmahIo(o => 
            {
                o.ApiKey = builder.Configuration["ElmahIo:ApiKey"];
                o.LogId = new Guid(builder.Configuration["ElmahIo:LogId"]);
            });

            builder.Logging.AddConsole();

            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = builder.Configuration["ElmahIo:ApiKey"];
                    options.LogId = new Guid(builder.Configuration["ElmahIo:LogId"]);                   
                    options.HeartbeatId = builder.Configuration["ElmahIo:HeartbeatId"];
                })
                .AddCheck("Produtos", new SqlServerHealthCheck(connectionString))
                .AddSqlServer(connectionString, name: "BancoSQL");

            services.AddHealthChecksUI()
                .AddSqlServerStorage(connectionString);

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            return app;
        }
    }
}