using DBManager.DTOs.Components;
using DBManager.Repositories;
using DistributorManager.DTOs;

namespace DistributorManager.Repositories;

public interface IDistributorRepository<T> where T: IPartDTO
{
    Task<T?> GetPartAsync(string productCode);
    IComponent GetComponent(T part);
    Task InsertPartIntoDb(MongoConnection mongoConnection, T part);
}