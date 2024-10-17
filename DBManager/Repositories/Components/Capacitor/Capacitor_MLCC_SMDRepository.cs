using DBManager.DTOs.Components.Capacitors;

namespace DBManager.Repositories.Components.Capacitor;

public class Capacitor_MLCC_SMDRepository: CapacitorRepository<Capacitor_MLCC_SMD>
{
    private static readonly string _connectionString = "capacitor_MLCC-SMD";

    public Capacitor_MLCC_SMDRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}