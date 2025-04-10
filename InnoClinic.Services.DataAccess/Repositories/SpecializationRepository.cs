using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.SpecializationModel;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public class SpecializationRepository : RepositoryBase<SpecializationEntity>, ISpecializationRepository
    {
        public SpecializationRepository(InnoClinicServicesDbContext context) : base(context) { }

        public async Task<IEnumerable<SpecializationEntity>> GetAllAsync()
        {
            return await _context.Specializations
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<SpecializationEntity>> GetAllActiveSpecializationsAsync()
        {
            return await _context.Specializations
                .AsNoTracking()
                .Where(s => s.IsActive)
                .ToListAsync();
        }

        public async Task<SpecializationEntity> GetByIdAsync(Guid id)
        {
            return await _context.Specializations
                .FirstOrDefaultAsync(s => s.Id.Equals(id))
                ?? throw new DataRepositoryException($"Specialization with Id '{id}' not found.", StatusCodes.Status404NotFound);
        }
    }
}