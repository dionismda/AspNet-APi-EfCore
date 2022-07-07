using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Api_EfCore.Repositories
{
    public abstract class BaseRepository<TModel, TContext> : IRepository<TModel>
        where TModel : class, IModel
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TModel> Add(TModel entity)
        {
            await _context.Set<TModel>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TModel>> GetAll()
        {
            return await _context.Set<TModel>().AsNoTracking().ToListAsync();
        }

        public async Task<TModel> GetById(int id)
        {
            return await _context.Set<TModel>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IPagination<TModel>> GetPaginationAsync(PaginationRequest request, CancellationToken cancellationToken)
        {
            return await _context.Set<TModel>().PaginationAsync(request, cancellationToken);
        }

        public async Task<TModel> Update(TModel entity)
        {
            _context.Set<TModel>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
