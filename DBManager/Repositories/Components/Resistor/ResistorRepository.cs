using DBManager.DTOs.Components.Resistors;

namespace DBManager.Repositories.Components.Resistor;

public class ResistorRepository<T>: ComponentsRepository<T>, IResistorRepository<T> where T: IResistor
{
    public ResistorRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
    }

    public async Task<IEnumerable<T>> GetByFootprintAsync(string footprint)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetByResistanceAsync(string footprint)
    {
        throw new NotImplementedException();
    }
}