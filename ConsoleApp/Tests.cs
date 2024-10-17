using System.Text.Json;
using DBManager.DTOs.Components;
using DBManager.DTOs.Components.Resistors;
using DBManager.Repositories;
using DBManager.Repositories.Components.Resistor;
using DistributorManager.DTOs;
using DistributorManager.DTOs.LCSC;
using DistributorManager.Repositories.LCSC;

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
        IComponent r3 = TestInheritance();
        await repository.CreateAsync((Resistor_SMD)r3);
        Console.WriteLine(JsonSerializer.Serialize((await repository.GetAllAsync()).ToList()));
    }

    private static IComponent TestInheritance()
    {
        Resistor_SMD r1 = new Resistor_SMD()
        {
            Footprint = new ComponentParameter<string>("Working0805"),
            Resistance = new ComponentParameter<double>(1000d, "1k"),
            Tolerance = new ComponentParameter<string>("+-1"),
        };
        return r1;
    }

    public static async Task Run2(string connectionString, string dbName)
    {
        string code = "C22548";
        LCSCRepository lcscRepository = new LCSCRepository();
        MongoConnection mongoConnection = new MongoConnection(connectionString, dbName);
        
        LCSCPartDTO? part = await lcscRepository.GetPartAsync(code);
        if (part is not null)
        {
            await lcscRepository.InsertPartIntoDb(mongoConnection, part);
        }
    }
}