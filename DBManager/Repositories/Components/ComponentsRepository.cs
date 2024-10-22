using DBManager.DTOs.Components;

namespace DBManager.Repositories.Components;

public class ComponentsRepository<T>: StrippedComponentsRepository<T>, IComponentsRepository<T> where T: IComponent
{
    private readonly StrippedComponentsRepository<StrippedComponent> _strippedComponentsRepository;
    public ComponentsRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
        _strippedComponentsRepository = new StrippedComponentsRepository<StrippedComponent>(mongoConnection);
    }
    
    //TODO better atomic crud management 
    public override async Task CreateAsync(T component)
    {
        await base.CreateAsync(component);
        await _strippedComponentsRepository.CreateAsync(component.ToStripped());
    }

    public override async Task<bool> UpdateOneAsync(T component)
    {
        await base.UpdateOneAsync(component);
        return await _strippedComponentsRepository.UpdateOneAsync(component.ToStripped());
    }

    public override async Task<bool> DeleteOneAsync(T component)
    {
        await base.DeleteOneAsync(component);
        return await _strippedComponentsRepository.DeleteOneAsync(component.ToStripped());
    }
}