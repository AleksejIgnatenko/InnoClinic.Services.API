using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public class MedicalServiceRepository : RepositoryBase<MedicalServiceModel>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(InnoClinicServicesDbContext context) : base(context) { }

        public async Task<IEnumerable<MedicalServiceModel>> GetAllAsync()
        {
            return await _context.MedicalService
                .AsNoTracking()
                .Where(m => m.IsActive)
                .Include(m => m.ServiceCategory)
                .Include(m => m.Specialization)
                .ToListAsync();
        }

        public async Task<MedicalServiceModel> GetByIdAsync(Guid id)
        {
            return await _context.MedicalService
            .FirstOrDefaultAsync(m => m.Id.Equals(id))
            ?? throw new DataRepositoryException($"Service with Id '{id}' not found.", StatusCodes.Status404NotFound); ;
        }
    }
}
