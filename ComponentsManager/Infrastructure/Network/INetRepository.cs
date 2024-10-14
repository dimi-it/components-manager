using ComponentsManager.Infrastructure.Databases.DTOs;

namespace ComponentsManager.Infrastructure.Network;

public interface INetRepository<T> where T: IPartNetDTO
{
    Task<T?> GetPartNetAsync(string productCode);
    Task<DistributorPartDbDTO?> GetDistributorPartAsync(string productCode);
}