using Asp.Versioning.ApiExplorer;
using AVS.DevStore.API.Configurations;

namespace AVS.DevStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();
            }

            // Configure Service
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            builder.Services.AddPersistenceConfig(builder.Configuration);

            builder.Services.AddIdentityConfig(builder.Configuration);

            builder.Services.AddApiConfiguration(); 

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSwaggerConfig();

            builder.Services.AddLoggingConfig(builder);

            builder.Services.ResolveDependencies();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Configure
            app.UseApiConfig(app.Environment);

            app.UseSwaggerConfig(apiVersionDescriptionProvider);

            app.UseLoggingConfiguration();

            app.Run();
        }
    }
}
