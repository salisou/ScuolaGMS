using Api.Data;
using Api.GenericRepositories.Interfaces;
using Api.GenericRepositories.Iterfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.GenericRepositories.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScuolaDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(ScuolaDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
                _dbset.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
