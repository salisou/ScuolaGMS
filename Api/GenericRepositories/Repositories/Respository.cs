using Api.Data;
using Api.GenericRepositories.Iterfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.GenericRepositories.Repositories
{
    public class Respository<T> : IGeniricRepositoy<T> where T : class
    {
        private readonly ScuolaDbContext _context;
        private readonly DbSet<T> _dbset;

        public Respository(ScuolaDbContext context, DbSet<T> dbset)
        {
            _context = context;
            _dbset = dbset;
        }

        public async Task<IEnumerable<T>> GatAllAsync()=> await _dbset.ToListAsync();
        
        public async Task<T?> GetByIdAsync(int id) => await _dbset.FindAsync(id);

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
