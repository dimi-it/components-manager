using DBManager.Const;
using DBManager.DTOs.Components.Resistors;
using MongoDB.Driver;

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

    public async Task<IEnumerable<T>> GetByFootprintAsync(string footprint)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(resistor => resistor.Footprint.Value == footprint);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByResistanceAsync(double resistance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(resistor => Math.Abs(resistor.Resistance.Value - resistance) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByToleranceAsync(string tolerance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(resistor => resistor.Tolerance.Value == tolerance);
        return result.ToEnumerable();
    }
}