using System.Text.Json;
using DBManager.DTOs.Components;
using DBManager.DTOs.Components.Resistors;
using DBManager.Repositories;
using DBManager.Repositories.Components.Resistor;

namespace ConsoleApp;

public static class Tests
{
    public static async Task Run1(string connectionString, string dbName)
    {
        Console.WriteLine("RUN 1");
        Resistor_SMDRepository repository = new Resistor_SMDRepository(new MongoConnection(connectionString, dbName));
        Resistor_SMD r1 = new Resistor_SMD()
        {
            Vendor = "Io",
            VendorProductCode = "code2",
            Footprint = "0805",
            Resistance = new ComponentParameter<double>(1000.0, "1kΩ"),
            Tolerance = new ComponentParameter<string>("+=1")
        };
        await repository.CreateAsync(r1);
        Console.WriteLine(JsonSerializer.Serialize((await repository.GetAllAsync()).ToList()));
    }
}