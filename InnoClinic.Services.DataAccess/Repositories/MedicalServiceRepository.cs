using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.MedicalServiceModels;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public class MedicalServiceRepository : RepositoryBase<MedicalServiceEntity>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(InnoClinicServicesDbContext context) : base(context) { }

        public async Task<IEnumerable<MedicalServiceEntity>> GetAllAsync()
        {
            return await _context.MedicalServices
                .AsNoTracking()
                .Include(m => m.ServiceCategory)
                .Include(m => m.Specialization)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicalServiceEntity>> GetBySpecializationIdAsync(Guid specializationId)
        {
            return await _context.MedicalServices
                .AsNoTracking()
                .Where(s => s.Specialization.Id.Equals(specializationId))
                .Include(m => m.ServiceCategory)
                .Include(m => m.Specialization)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicalServiceEntity>> GetAllActiveMedicalServicesAsync()
        {
            return await _context.MedicalServices
                .AsNoTracking()
                .Where(m => m.IsActive)
                .Include(m => m.ServiceCategory)
                .Include(m => m.Specialization)
                .ToListAsync();
        }

        public async Task<MedicalServiceEntity> GetByIdAsync(Guid id)
        {
            return await _context.MedicalServices
            .Include(m => m.ServiceCategory)
            .Include(m => m.Specialization)
            .FirstOrDefaultAsync(m => m.Id.Equals(id))
            ?? throw new DataRepositoryException($"Service with Id '{id}' not found.", StatusCodes.Status404NotFound); ;
        }
    }
}
