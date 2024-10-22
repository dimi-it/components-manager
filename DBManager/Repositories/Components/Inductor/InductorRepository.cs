using DBManager.Const;
using DBManager.DTOs.Components.Inductor;
using MongoDB.Driver;

namespace DBManager.Repositories.Components.Inductor;

public class InductorRepository<T>: ComponentsRepository<T>, IInductorRepository<T> where T: IInductor
{
    public InductorRepository(MongoConnection mongoConnection, string collectionName) : base(mongoConnection, collectionName)
    {
    }
    
    public override async Task CreateAsync(T inductor)
    {
        if (inductor.Name is null)
        {
            inductor.SetDefaultName();
        }
        await base.CreateAsync(inductor);
    }

    public async Task<IEnumerable<T>> GetByFootprintAsync(string footprint)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(inductor => inductor.Footprint.Value == footprint);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByInductanceAsync(double inductance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(inductor => Math.Abs(inductor.Inductance.Value - inductance) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByToleranceAsync(string tolerance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(inductor => inductor.Tolerance.Value == tolerance);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByRatedCurrentAsync(double ratedCurrent)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(inductor =>
            Math.Abs(inductor.RatedCurrent.Value - ratedCurrent) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }

    public async Task<IEnumerable<T>> GetByDCResistanceAsync(double dcResistance)
    {
        IAsyncCursor<T> result = await Collection.FindAsync(inductor => Math.Abs(inductor.DCResistance.Value - dcResistance) < DBConst.COMPARISION_TOLERANCE);
        return result.ToEnumerable();
    }
}