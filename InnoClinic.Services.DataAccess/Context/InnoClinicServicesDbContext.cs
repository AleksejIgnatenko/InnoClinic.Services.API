using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Context;

/// <summary>
/// Represents the database context for InnoClinic services.
/// </summary>
public class InnoClinicServicesDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet of service categories.
    /// </summary>
    public DbSet<ServiceCategoryEntity> ServiceCategories { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of medical services.
    /// </summary>
    public DbSet<MedicalServiceEntity> MedicalServices { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of specializations.
    /// </summary>
    public DbSet<SpecializationEntity> Specializations { get; set; }

    /// <summary>
    /// Initializes a new instance of the InnoClinicServicesDbContext class with the specified options.
    /// </summary>
    /// <param name="options">The options for the context.</param>
    public InnoClinicServicesDbContext(DbContextOptions<InnoClinicServicesDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Configures the model for the database context.
    /// </summary>
    /// <param name="modelBuilder">The model builder to use for configuration.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceCategoryEntity>().HasData(
            new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Analyses", TimeSlotSize = 10 },
            new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Consultation", TimeSlotSize = 20 },
            new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Diagnostics", TimeSlotSize = 30 }
        );
    }
}