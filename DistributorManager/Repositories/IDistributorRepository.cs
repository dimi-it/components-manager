using DBManager.DTOs;
using DistributorManager.DTOs;

namespace DistributorManager.Repositories;

public interface IDistributorRepository<T> where T: IPartDTO
{
    Task<T?> GetPartNetAsync(string productCode);
    Task<DistributorPartDbDTO?> GetDistributorPartAsync(string productCode);
}