using ComponentsManager.Infrastructure.Databases.DTOs;
using MongoDB.Driver;

namespace ComponentsManager.Infrastructure.Databases.Repositories;

public class DistributorPartDbRepository: BaseDbRepository<DistributorPartDbDTO>
{
    private static string _collectionName = "distributorPart";
    
    public DistributorPartDbRepository(MongoConnection mongoConnection, string? collectionName = null) : base(mongoConnection, collectionName ?? _collectionName)
    {
        _collectionName = collectionName ?? _collectionName;
    }
    
    public async Task<DistributorPartDbDTO?> GetByVendorProductCodeAsync(string vendorProductCode)
    {
        IAsyncCursor<DistributorPartDbDTO> result = await Collection.FindAsync(t => t.VendorProductCode == vendorProductCode);
        return await result.FirstOrDefaultAsync();
    }
    
    public async Task<DistributorPartDbDTO?> GetByManufacturerProductCodeAsync(string manufacturerProductCode)
    {
        IAsyncCursor<DistributorPartDbDTO> result = await Collection.FindAsync(t => t.ManufacturerProductCode == manufacturerProductCode);
        return await result.FirstOrDefaultAsync();

    }
}