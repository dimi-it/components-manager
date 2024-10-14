// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Databases.Repositories;
using ComponentsManager.Infrastructure.Network.LCSC;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;

Console.WriteLine("Hello, I'm your Components Manager!");

string partCode = "C2934560";
string connectionString = "mongodb://mongo_user:mongo_pswd@localhost:27017/";
string dbName = "componentsDb";

LCSCRepository lcscRepository = new LCSCRepository();
DistributorPartDbRepository distributorPartDbRepository = new DistributorPartDbRepository(new MongoConnection(connectionString, dbName));

try
{
    DistributorPartDbDTO? part = await lcscRepository.GetDistributorPartAsync(partCode);
    if (part is not null)
    {
        // Console.WriteLine(part.ToString());
        // await distributorPartDbRepository.CreateAsync(part);

        if (await distributorPartDbRepository.GetByVendorProductCodeAsync(part.VendorProductCode) is null)
        {
            Console.WriteLine($"{part.ManufacturerProductCode} added to db");
            await distributorPartDbRepository.CreateAsync(part);
        }
        else
        {
            Console.WriteLine($"{part.ManufacturerProductCode} already present");
        }
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


