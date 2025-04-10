using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.Core.Models.SpecializationModel;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Context
{
    public class InnoClinicServicesDbContext : DbContext
    {
        public DbSet<ServiceCategoryEntity> ServiceCategories { get; set; }
        public DbSet<MedicalServiceEntity> MedicalServices { get; set; }
        public DbSet<SpecializationEntity> Specializations { get; set; }

        public InnoClinicServicesDbContext(DbContextOptions<InnoClinicServicesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCategoryEntity>().HasData(
                new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Analyses", TimeSlotSize = 10 },
                new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Consultation", TimeSlotSize = 20 },
                new ServiceCategoryEntity { Id = Guid.NewGuid(), CategoryName = "Diagnostics", TimeSlotSize = 30 }
            );
        }
    }
}
