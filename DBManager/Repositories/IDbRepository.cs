using DBManager.DTOs;

namespace DBManager.Repositories;

public interface IDbRepository<T> where T: IDbEntity
{
    Task CreateAsync(T t);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task<bool> UpdateOneAsync(T t);
    Task<bool> DeleteOneAsync(T t);
}