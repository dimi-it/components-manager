using DBManager.DTOs.Components;

namespace DBManager.Repositories.Components;

public class ComponentsRepository<T>: BaseDbRepository<T>, IComponentsRepository<T> where T: IComponent
{
    //TODO add a component only collection with stripped dat => manage CRUD
    public ComponentsRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
    }

    public Task<T?> GetByManufacturerProductCodeAsync(string manufacturerProductCode)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByVendorProductCodeAsync(string vendorProductCode)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetByManufacturerAsync(string manufacturer)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetByVendorAsync(string vendor)
    {
        throw new NotImplementedException();
    }
}