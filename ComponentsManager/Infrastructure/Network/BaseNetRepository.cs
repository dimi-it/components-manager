using DBManager.DTOs;

namespace ComponentsManager.Infrastructure.Network;

public abstract class BaseNetRepository<T>: INetRepository<T> where T: IPartNetDTO
{
    public abstract Task<T?> GetPartNetAsync(string productCode);

    public async Task<DistributorPartDbDTO?> GetDistributorPartAsync(string productCode)
    {
        T? part = await GetPartNetAsync(productCode);
        return part?.TryToDistributorPartDbDTO();
    }
}