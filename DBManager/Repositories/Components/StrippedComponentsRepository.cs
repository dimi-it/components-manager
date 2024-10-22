using DBManager.DTOs.Components;
using MongoDB.Driver;

namespace DBManager.Repositories.Components;

public class StrippedComponentsRepository<T>: BaseDbRepository<T>, IStrippedComponentsRepository<T> where T: IStrippedComponent
{
    private static readonly string _connectionString = "strippedComponents";

    public StrippedComponentsRepository(MongoConnection mongoConnection, string? collectionName = null)
        : base(mongoConnection, collectionName ?? _connectionString)
    {
        
    }

    public override async Task CreateAsync(T component)
    {
        if (component.Name is null)
        {
            throw new ArgumentNullException($"{nameof(component)}", "A component with Name null cannot be stored.");
        }
        if (component.ManufacturerProductCode is not null)
        {
            T? result = await GetByManufacturerProductCodeAsync(component.ManufacturerProductCode);
            if (result is not null)
            {
                throw new InvalidOperationException($"A components with Manufacturer Product Code {component.ManufacturerProductCode} is already present!");
            }
        }
        if (component.VendorProductCode is not null)
        {
            T? result = await GetByVendorProductCodeAsync(component.VendorProductCode);
            if (result is not null)
            {
                throw new InvalidOperationException($"A components with Vendor Product Code {component.VendorProductCode} is already present!");
            }
        }
        await base.CreateAsync(component);
    }

    public async Task<T?> GetByManufacturerProductCodeAsync(string manufacturerProductCode)
    {
        IAsyncCursor<T> result = await Collection
            .FindAsync(component => component.ManufacturerProductCode == manufacturerProductCode);
        return await result.SingleOrDefaultAsync();
    }

    public async Task<T?> GetByVendorProductCodeAsync(string vendorProductCode)
    {
        IAsyncCursor<T> result = await Collection
            .FindAsync(component => component.VendorProductCode == vendorProductCode);
        return await result.SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetByNameAsync(string name)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(component => component.Name == name);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByManufacturerAsync(string manufacturer)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(component => component.Manufacturer == manufacturer);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByVendorAsync(string vendor)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(component => component.Vendor == vendor);
        return result.ToEnumerable();
    }
}