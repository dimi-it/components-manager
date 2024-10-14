// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Databases.Repositories;
using ComponentsManager.Infrastructure.Network.LCSC;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;

Console.WriteLine("Hello, I'm your Components Manager!");

string connectionString = "mongodb://mongo_user:mongo_pswd@localhost:27017/";
string dbName = "componentsDb";

LCSCRepository lcscRepository = new LCSCRepository();
DistributorPartDbRepository distributorPartDbRepository = new DistributorPartDbRepository(new MongoConnection(connectionString, dbName));



async Task TryInsert(string partCode)
{
    if (await distributorPartDbRepository.GetByVendorProductCodeAsync(partCode) is null)
    {
        try
        {
            DistributorPartDbDTO? part = await lcscRepository.GetDistributorPartAsync(partCode);
            if (part is not null)
            {
                Console.WriteLine($"{part.VendorProductCode} added to db");
                await distributorPartDbRepository.CreateAsync(part);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Error, missing: {e.Message}");
        }
    }
    else
    {
        Console.WriteLine($"{partCode} already present");
    }
    
}

