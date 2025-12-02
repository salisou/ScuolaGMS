
using Api.Data;
using Api.GenericRepositories.Interfaces;
using Api.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.GenericRepositories.Repositories
{
    public class GRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScuolaDbContext _context;
        private readonly DbSet<T> _dbset;

        public GRepository(ScuolaDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<ApiResponse<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                var items = await _dbset.ToListAsync();
                if (items.Count == 0)
                    return ApiResponse<IEnumerable<T>>.Fail("Nessun dato trovato.");
                return ApiResponse<IEnumerable<T>>.Ok(items, "Dati recuperati con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<T>>.Fail($"Errore durante il recupero: {ex.Message}");
            }
        }

        public async Task<ApiResponse<T?>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbset.FindAsync(id);
                if (entity == null)
                    return ApiResponse<T?>.Fail("Entità non trovata.");
                return ApiResponse<T?>.Ok(entity, "Entità recuperata con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<T?>.Fail($"Errore durante la ricerca: {ex.Message}");
            }
        }

        public async Task<ApiResponse<T>> InsertAsync(T entity)
        {
            if (entity == null)
                return ApiResponse<T>.Fail("Entità non valida.");
            await _dbset.AddAsync(entity);
            return ApiResponse<T>.Ok(entity, "Entità aggiunta (non ancora salvata).");
        }

        public async Task<ApiResponse<T>> UpdateAsync(T entity)
        {
            if (entity == null)
                return ApiResponse<T>.Fail("Entità non valida.");
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(ApiResponse<T>.Ok(entity, "Entità aggiornata (non ancora salvata)."));
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbset.FindAsync(id);
                if (entity == null)
                    return ApiResponse<bool>.Fail("Entità non trovata.");
                _dbset.Remove(entity);
                return ApiResponse<bool>.Ok(true, "Entità rimossa (non ancora salvata).");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore durante l'eliminazione: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return ApiResponse<bool>.Ok(true, "Salvataggio eseguito con successo.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail($"Errore durante il salvataggio: {ex.Message}");
            }
        }
    }
}
