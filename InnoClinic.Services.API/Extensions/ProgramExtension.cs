using InnoClinic.Services.API.Middlewares;
using InnoClinic.Services.Application;
using InnoClinic.Services.Application.MapperProfiles;
using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.DataAccess;
using InnoClinic.Services.Infrastructure.Options.Jwt;
using InnoClinic.Services.Infrastructure.Options.RabbitMQ;
using Microsoft.Extensions.Options;
using Serilog;

namespace InnoClinic.Services.API.Extensions;

/// <summary>
/// Contains extension methods for configuring the web application builder and application startup.
/// </summary>
public static class ProgramExtension
{
    /// <summary>
    /// Configures the web application builder with necessary services and configurations.
    /// </summary>
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .CreateSerilog(builder.Host);

        builder.Configuration
            .AddEnvironmentVariables()
            .LoadConfiguration();

        builder.Services
            .AddOptions(builder.Configuration)
            .AddDbContext(builder.Configuration)
            .AddRepositories()
            .AddServices()
            .AddSwaggerGen()
            .AddEndpointsApiExplorer()
            .AddJwtAuthentication(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>())
            .AddMapperProfiles()
            .AddControllers();

        return builder;
    }

    /// <summary>
    /// Configures the web application with necessary middleware and services during startup.
    /// </summary>
    public static async Task<WebApplication> ConfigureApplicationAsync(this WebApplication app)
    {
        app.UseCustomExceptionHandler();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var rabbitMQService = services.GetRequiredService<IRabbitMQService>();
            await rabbitMQService.CreateQueuesAsync();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    private static IConfiguration LoadConfiguration(this IConfigurationBuilder configuration)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        return configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .Build();
    }

    private static IServiceCollection AddOptions(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RabbitMQOptions>(configuration.GetSection(nameof(RabbitMQOptions)));
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

        return services;
    }

    private static IServiceCollection AddMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MedicalServiceMapperProfile), 
                               typeof(SpecializationMapperProfile));

        return services;
    }

    private static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder webApplication)
    {
        webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

        return webApplication;
    }
}