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
        Component c = new Component()
        {
            Name = "resWOo",
            VendorProductCode = "15",
            Vendor = "LCSC"
        };
        Resistor_SMD r1 = new Resistor_SMD()
        {
            Footprint = new ComponentParameter<string>("0805"),
            Resistance = new ComponentParameter<double>(1000d, "1k"),
            Tolerance = new ComponentParameter<string>("+-1"),
        };
        Resistor_SMD r2 = new Resistor_SMD(c)
        {
            Footprint = new ComponentParameter<string>("080225"),
            Resistance = new ComponentParameter<double>(1000d, "1k"),
            Tolerance = new ComponentParameter<string>("+-1"),
        };
        await repository.CreateAsync(r2);
        Console.WriteLine(JsonSerializer.Serialize((await repository.GetAllAsync()).ToList()));
    }
}