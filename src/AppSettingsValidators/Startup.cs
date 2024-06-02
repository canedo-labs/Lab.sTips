using AppSettingsValidators.Configurations.Extensions;
using AppSettingsValidators.Configurations.Settings;

namespace AppSettingsValidators
{
    public class Startup
    {
        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // If want inject by IOptions.
            services.AddOptionsWithValidation<PoCoOptionsSettings>("PoCoOptionsSettings");

            // If want inject by IOptions to validate and by type directly.
            services.AddSettingsWithValidation<PoCoSettings>("PoCoSettings");

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

        public void Run(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            var configuration = 
                builder
                .Configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables()
                .AddCommandLine(args)                
                .Build();

            ConfigureServices(builder.Services, configuration);
            
            var app = builder.Build();
            
            Configure(app);
            
            app.Run();
        }
    }
}
