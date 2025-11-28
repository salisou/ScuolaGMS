
using Api.Data;
using Api.GenericRepositories.Interfaces;
using Api.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.GenericRepositories.Repositories
{
    /// <summary>
    /// Implementazione generica del repository pattern.
    /// </summary>
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScuolaDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(ScuolaDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<ApiResponse<IEnumerable<T>>> GetAllAsync()
        {
            var items = await _dbset.ToListAsync();
            if (items.Count == 0)
                return ApiResponse<IEnumerable<T>>.Fail("Tabella vuota!");
            return ApiResponse<IEnumerable<T>>.Ok(items);
        }

        public async Task<ApiResponse<T?>> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity == null)
                return ApiResponse<T?>.Fail("Entità non trovata!");
            return ApiResponse<T?>.Ok(entity);
        }

        public async Task<ApiResponse<T>> InsertAsync(T entity)
        {
            await _dbset.AddAsync(entity);
            return ApiResponse<T>.Ok(entity, "Entità aggiunta (non ancora salvata)");
        }

        public Task<ApiResponse<T>> UpdateAsync(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(ApiResponse<T>.Ok(entity, "Entità aggiornata (non ancora salvata)"));
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            T? entity = await _dbset.FindAsync(id);
            if (entity == null)
                return ApiResponse<bool>.Fail("Entità non trovata!");
            _dbset.Remove(entity);
            return ApiResponse<bool>.Ok(true, "Entità rimossa (non ancora salvata)");
        }

        public async Task<ApiResponse<bool>> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return ApiResponse<bool>.Ok(true, "Salvataggio eseguito.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore durante il salvataggio: {ex.Message}");
            }
        }
    }
}
