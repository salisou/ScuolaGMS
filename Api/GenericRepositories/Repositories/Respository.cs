using Api.Data;
using Api.GenericRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.GenericRepositories.Repositories
{
    /// <summary>
    /// Implementazione generica del repository pattern.
    /// Consente di eseguire operazioni CRUD per qualsiasi entità del database.
    /// </summary>
    /// <typeparam name="T">Il tipo di entità su cui operare (classe).</typeparam>
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly ScuolaDbContext _context;
        private readonly DbSet<T> _dbset;

        /// <summary>
        /// Costruttore che inizializza il contesto e il DbSet associato al tipo T.
        /// </summary>
        /// <param name="context">Il DbContext utilizzato per l'accesso al database.</param>
        public Repository(ScuolaDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>(); // DbSet generico
        }

        /// <summary>
        /// Restituisce tutte le entità presenti nella tabella corrispondente.
        /// </summary>
        /// <returns>Una collezione di entità di tipo T.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        /// <summary>
        /// Cerca un'entità in base al suo identificatore primario.
        /// </summary>
        /// <param name="id">L'ID dell'entità da recuperare.</param>
        /// <returns>L'entità trovata oppure null se non esiste.</returns>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        /// <summary>
        /// Inserisce una nuova entità nel database.
        /// </summary>
        /// <param name="entity">L'entità da inserire.</param>
        public async Task InsertAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        /// <summary>
        /// Aggiorna un'entità esistente.
        /// </summary>
        /// <param name="entity">L'entità modificata.</param>
        public Task UpdateAsync(T entity)
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        /// <summary>
        /// Elimina un'entità in base al suo ID.
        /// </summary>
        /// <param name="id">L'ID dell'entità da eliminare.</param>
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
                _dbset.Remove(entity);
        }

        /// <summary>
        /// Salva tutte le modifiche pendenti nel database.
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
