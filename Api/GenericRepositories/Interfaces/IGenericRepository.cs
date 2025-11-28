
using Api.Responses;

namespace Api.GenericRepositories.Interfaces
{
    /// <summary>
    /// Interfaccia generica per operazioni CRUD.
    /// </summary>
    /// <typeparam name="T">Tipo di entità.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        Task<ApiResponse<IEnumerable<T>>> GetAllAsync();
        Task<ApiResponse<T?>> GetByIdAsync(int id);
        Task<ApiResponse<T>> InsertAsync(T entity);
        Task<ApiResponse<T>> UpdateAsync(T entity);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<bool>> SaveAsync();
    }
}
