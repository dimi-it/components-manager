using ComponentsManager.Infrastructure.Network.DTOs;

namespace ComponentsManager.Infrastructure.Network.Repositories;

public interface INetRepository<T> where T: IResultNetDTO
{
    Task<T?> GetPartAsync(string productCode);
}