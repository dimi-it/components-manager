using DBManager.DTOs.Components;

namespace DBManager.Repositories.Components;

public interface IComponentsRepository<T> where T: IComponent
{
    Task<T?> GetByManufacturerProductCodeAsync(string manufacturerProductCode);
    Task<T?> GetByVendorProductCodeAsync(string vendorProductCode);
    Task<IEnumerable<T>> GetByNameAsync(string name);
    Task<IEnumerable<T>> GetByManufacturerAsync(string manufacturer);
    Task<IEnumerable<T>> GetByVendorAsync(string vendor);
}