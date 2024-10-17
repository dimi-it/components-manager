using DBManager.DTOs.Components.Capacitors;

namespace DBManager.Repositories.Components.Capacitor;

public class Capacitor_Electrolytic_LeadedRepository: CapacitorRepository<Capacitor_Electrolytic_Leaded>
{
    private static readonly string _connectionString = "capacitor_Electrolytic-Leaded";

    public Capacitor_Electrolytic_LeadedRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}