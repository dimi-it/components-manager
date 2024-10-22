using DBManager.DTOs.Components.Inductor;

namespace DBManager.Repositories.Components.Inductor;

public class InductorSMDRepository: InductorRepository<InductorSMD>
{
    private static readonly string _connectionString = "InductorSMD";

    public InductorSMDRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}