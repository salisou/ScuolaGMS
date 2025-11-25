namespace Api.GenericRepositories.Interfaces
{
    /// <summary>
    /// Interfaccia generica che definisce le operazioni CRUD di base
    /// per qualsiasi entità del database.
    /// </summary>
    /// <typeparam name="T">Il tipo di entità su cui operare.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Recupera tutte le entità della tabella associata.
        /// </summary>
        /// <returns>
        /// Una collezione di entità di tipo <typeparamref name="T"/>.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Recupera una singola entità in base al suo identificatore.
        /// </summary>
        /// <param name="id">L'identificatore primario dell'entità.</param>
        /// <returns>
        /// L'entità trovata oppure <c>null</c> se non esiste.
        /// </returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Inserisce una nuova entità nel database.
        /// </summary>
        /// <param name="entity">L'entità da inserire.</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// Aggiorna un'entità esistente.
        /// </summary>
        /// <param name="entity">L'entità modificata.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Elimina un'entità dal database tramite il suo ID.
        /// </summary>
        /// <param name="id">L'identificatore dell'entità da eliminare.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Salva tutte le modifiche pendenti nel database.
        /// </summary>
        Task SaveAsync();
    }
}
