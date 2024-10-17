using DBManager.Const;
using DBManager.DTOs.Components.Capacitors;
using MongoDB.Driver;

namespace DBManager.Repositories.Components.Capacitor;

public class CapacitorRepository<T>: ComponentsRepository<T>, ICapacitorRepository<T> where T: ICapacitor
{
    public CapacitorRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
    }
    
    public override async Task CreateAsync(T capacitor)
    {
        if (capacitor.Name is null)
        {
            capacitor.SetDefaultName();
        }
        await base.CreateAsync(capacitor);
    }

    public async Task<IEnumerable<T>> GetByFootprintAsync(string footprint)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(capacitor => capacitor.Footprint.Value == footprint);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByCapacitanceAsync(double capacitance)
    {
        IAsyncCursor<T> result = await Collection
            .FindAsync(capacitor => Math.Abs(capacitor.Capacitance.Value - capacitance) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByToleranceAsync(string tolerance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(capacitor => capacitor.Tolerance.Value == tolerance);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByRatedVoltageAsync(double ratedVoltage)
    {
        IAsyncCursor<T> result = await Collection
            .FindAsync(capacitor => Math.Abs(capacitor.RatedVoltage.Value - ratedVoltage) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }
}