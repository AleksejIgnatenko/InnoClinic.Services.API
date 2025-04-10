using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models.ServiceCategoryModels;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public class ServiceCategoryRepository : RepositoryBase<ServiceCategoryEntity>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(InnoClinicServicesDbContext context) : base(context) { }

        public async Task<IEnumerable<ServiceCategoryEntity>> GetAllAsync()
        {
            return await _context.ServiceCategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ServiceCategoryEntity> GetByIdAsync(Guid id)
        {
            return await _context.ServiceCategories
            .FirstOrDefaultAsync(s => s.Id.Equals(id))
            ?? throw new DataRepositoryException($"Service category with Id '{id}' not found.", StatusCodes.Status404NotFound); ;
        }
    }
}
