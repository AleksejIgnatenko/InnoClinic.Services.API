using InnoClinic.Services.Core.Exceptions;
using InnoClinic.Services.Core.Models;
using InnoClinic.Services.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.Services.DataAccess.Repositories
{
    public class ServiceCategoryRepository : RepositoryBase<ServiceCategoryModel>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(InnoClinicServicesDbContext context) : base(context) { }

        public async Task<IEnumerable<ServiceCategoryModel>> GetAllAsync()
        {
            return await _context.ServiceCategories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ServiceCategoryModel> GetByIdAsync(Guid id)
        {
            return await _context.ServiceCategories
            .FirstOrDefaultAsync(s => s.Id.Equals(id))
            ?? throw new DataRepositoryException($"Service category with Id '{id}' not found.", StatusCodes.Status404NotFound); ;
        }
    }
}
