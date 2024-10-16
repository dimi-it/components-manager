using DBManager.DTOs.Components.Resistors;

namespace DBManager.Repositories.Components.Resistor;

public class Resistor_SMDRepository: ResistorRepository<Resistor_SMD>
{
    private static readonly string _connectionString = "resistor_SMD";
    
    public Resistor_SMDRepository(MongoConnection mongoConnection, string? collectionName = null) 
        : base(mongoConnection, collectionName ?? _connectionString)
    {
    }
}