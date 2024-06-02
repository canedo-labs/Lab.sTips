using Microsoft.Extensions.Options;

namespace AppSettingsValidators.Configurations.Extensions
{
    public static class AddSettingsExtension
    {
        public static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services, string sectionName)
            where TOptions : class
        {
            services
                .AddOptionsWithValidateOnStart<TOptions>(sectionName)
                .ValidateDataAnnotations();

            return services;
        }

        public static IServiceCollection AddSettingsWithValidation<TSettings>(this IServiceCollection services, string sectionName)
            where TSettings : class
        {
            services.AddOptionsWithValidation<TSettings>(sectionName);

            services.AddSingleton(serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<TSettings>>();

                return options.Value;
            });

            return services;
        }
    }
}
