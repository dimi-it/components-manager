using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Network.DTOs;

namespace ComponentsManager.Infrastructure.Network.Repositories;

public interface INetRepository<T> where T: IPartNetDTO
{
    Task<T?> GetPartNetAsync(string productCode);

    sealed async Task<DistributorPartDbDTO?> GetDistributorPartAsync(string productCode)
    {
        T? part = await GetPartNetAsync(productCode);
        return part?.ToDistributorPartDbDTO();
    }
}