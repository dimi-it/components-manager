using DBManager.DTOs.Components.Inductor;

namespace DBManager.Repositories.Components.Inductor;

public class InductorThroughHoleRepository: InductorRepository<InductorThroughHole>
{
    private static readonly string _connectionString = "InductorThroughHole";

    public InductorThroughHoleRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}