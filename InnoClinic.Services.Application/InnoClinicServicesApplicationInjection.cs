using FluentValidation;
using FluentValidation.AspNetCore;
using InnoClinic.Services.Application.Services;
using InnoClinic.Services.Application.Validators;
using InnoClinic.Services.Core.Abstractions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.Services.Application;

/// <summary>
/// Contains extension methods for adding services and FluentValidation to the service collection in the InnoClinic Services application.
/// </summary>
public static class InnoClinicServicesApplicationInjection
{
    /// <summary>
    /// Adds services related to RabbitMQ, service category management, specialization management and medical service management to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> with added services.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRabbitMQService, RabbitMQService>();
        services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        services.AddScoped<ISpecializationService, SpecializationService>();
        services.AddScoped<IMedicalServiceService, MedicalServiceService>();

        return services;
    }

    /// <summary>
    /// Adds FluentValidation services to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the FluentValidation services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidator();

        services.AddFluentValidationAutoValidation();

        return services;
    }

    private static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidator<MedicalServiceRequest>, MedicalServiceRequestValidator>();
        services.AddScoped<IValidator<ServiceCategoryRequest>, ServiceCategoryRequestValidator>();
        services.AddScoped<IValidator<SpecializationRequest>, SpecializationRequestValidator>();

        return services;
    }
}