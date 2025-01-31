using InnoClinic.Services.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Context
{
    public class InnoClinicServicesDbContext : DbContext
    {
        public DbSet<ServiceCategoryModel> ServiceCategories { get; set; }
        public DbSet<MedicalServiceModel> MedicalService { get; set; }
        public DbSet<SpecializationModel> Specializations { get; set; }

        public InnoClinicServicesDbContext(DbContextOptions<InnoClinicServicesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCategoryModel>().HasData(
                new ServiceCategoryModel { Id = Guid.NewGuid(), CategoryName = "Analyses", TimeSlotSize = 10 },
                new ServiceCategoryModel { Id = Guid.NewGuid(), CategoryName = "Consultation", TimeSlotSize = 20 },
                new ServiceCategoryModel { Id = Guid.NewGuid(), CategoryName = "Diagnostics", TimeSlotSize = 30 }
            );
        }
    }
}
