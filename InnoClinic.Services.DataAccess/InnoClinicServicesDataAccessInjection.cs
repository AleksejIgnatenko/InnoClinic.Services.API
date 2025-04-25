using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.DataAccess.Context;
using InnoClinic.Services.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.Services.DataAccess;

/// <summary>
/// Provides extension methods for registering data access dependencies related to InnoClinic services.
/// </summary>
public static class InnoClinicServicesDataAccessInjection
{
    /// <summary>
    /// Extension method to add a DbContext to the IServiceCollection with configuration for SQL Server.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the DbContext to.</param>
    /// <param name="configuration">The configuration containing the connection string.</param>
    /// <returns>The modified IServiceCollection with the added DbContext.</returns>
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InnoClinicServicesDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    /// <summary>
    /// Adds repositories to the service collection.
    /// </summary>
    /// <param name="services">The current <see cref="IServiceCollection"/>.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();
        services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
        services.AddScoped<ISpecializationRepository, SpecializationRepository>();

        return services;
    }
}