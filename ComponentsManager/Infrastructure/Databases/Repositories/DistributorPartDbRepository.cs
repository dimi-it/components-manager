using ComponentsManager.Infrastructure.Databases.Const;
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

    public override async Task CreateAsync(DistributorPartDbDTO part)
    {
        if (await GetByVendorProductCodeAsync(part.VendorProductCode) is null)
        {
            await base.CreateAsync(part);
        }
        else
        {
            throw new ArgumentException($"Distributor part {part.VendorProductCode} already present in collection");
        }
    }

    public async Task<DistributorPartDbDTO?> GetByVendorProductCodeAsync(string vendorProductCode)
    {
        IAsyncCursor<DistributorPartDbDTO> result = await Collection.FindAsync(part => part.VendorProductCode == vendorProductCode);
        return await result.FirstOrDefaultAsync();
    }
    
    public async Task<DistributorPartDbDTO?> GetByManufacturerProductCodeAsync(string manufacturerProductCode)
    {
        IAsyncCursor<DistributorPartDbDTO> result = await Collection.FindAsync(part => part.ManufacturerProductCode == manufacturerProductCode);
        return await result.FirstOrDefaultAsync();

    }
    
    public async Task<List<DistributorPartDbDTO>> GetAllByTopCategoryAsync(TopLevelCategory topLevelCategory)
    {
        IAsyncCursor<DistributorPartDbDTO> result = await Collection.FindAsync(part => part.CategoryDto.TopLevelCategory == topLevelCategory);
        return result.ToList();
    }
}