using DBManager.DTOs.Components.Capacitors;

namespace DBManager.Repositories.Components.Capacitor;

public class Capacitor_Electrolytic_SMDRepository: CapacitorRepository<Capacitor_Electrolytic_SMD>
{
    private static readonly string _connectionString = "Capacitor_Electrolytic_SMD";

    public Capacitor_Electrolytic_SMDRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}