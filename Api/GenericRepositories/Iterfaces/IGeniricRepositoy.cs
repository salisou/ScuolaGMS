namespace Api.GenericRepositories.Iterfaces
{
    public interface IGeniricRepositoy<T> where T : class
    {
        Task<IEnumerable<T>> GatAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
