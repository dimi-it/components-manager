using DBManager.DTOs;
using DistributorManager.DTOs;

namespace DistributorManager.Repositories;

public abstract class BaseDistributorRepository<T>: IDistributorRepository<T> where T: IPartDTO
{
    public abstract Task<T?> GetPartNetAsync(string productCode);

    public async Task<DistributorPartDbDTO?> GetDistributorPartAsync(string productCode)
    {
        T? part = await GetPartNetAsync(productCode);
        return part?.TryToDistributorPartDbDTO();
    }
}