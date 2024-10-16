using DBManager.DTOs.Components.Resistors;

namespace DBManager.Repositories.Components.Resistor;

public class ResistorRepository<T>: ComponentsRepository<T>, IResistorRepository<T> where T: IResistor
{
    public ResistorRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
    }

    public override async Task CreateAsync(T resistor)
    {
        if (resistor.Name is null)
        {
            resistor.SetDefaultName();
        }
        await base.CreateAsync(resistor);
    }

    public Task<IEnumerable<T>> GetByFootprintAsync(string footprint)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetByResistanceAsync(double resistance)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetByToleranceAsync(string tolerance)
    {
        throw new NotImplementedException();
    }
}