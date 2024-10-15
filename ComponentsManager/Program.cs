// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Network.LCSC;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;
using DBManager.DTOs;
using DBManager.Repositories;

Console.WriteLine("Hello, I'm your Components Manager!");

string connectionString = "mongodb://mongo_user:mongo_pswd@localhost:27017/";
string dbName = "componentsDb";

LCSCRepository lcscRepository = new LCSCRepository();
DistributorPartDbRepository distributorPartDbRepository = new DistributorPartDbRepository(new MongoConnection(connectionString, dbName));

string[] codes =
[
    "C2907329",
    // "C2933537",
    // "C2907294",
    // "C2907303",
    // "C2907326",
    // "C2930231",
    // "C2907309",
    // "C2907330",
    // "C2907293",
    // "C2907302",
    // "C2907321",
    // "C2930266",
    // "C2930276",
    // "C2907296",
    // "C2907310",
    // "C2907331",
    // "C2930296",
    // "C376929",
    // "C15850",
    // "C476766",
    // "C5674",
    // "C72487",
    // "C72505",
    // "C409116",
    // "C409115",
    // "C2827654",
    // "C2836062",
    // "C2843305",
    // "C355568",
    // "C397241",
    // "C5189747",
    // "C965815",
    // "C520860",
    // "C2934560",
    // "C5181460",
    // "C2895288",
    // "C2765186",
    // "C393013",
    // "C400542",
    // "C5379097",
    // "C2907232",
    // "C358170",
    // "C7419295",
    // "C7419296",
    // "C18199755",
    // "C18199753",
    // "C5274535",
    // "C5274533",
    // "C7419277",
    // "C7419293",
    // "C347207",
    // "C344177",
    // "C376859",
    // "C282728",
    // "C282721",
    // "C344201",
    // "C380343",
    // "C7464730",
    // "C3647085",
    // "C20628874",
    // "C5224270",
    // "C6562206",
    // "C5125722",
    // "C2929500",
    // "C5189749",
    // "C2930210",
    // "C2930238",
    // "C2933492",
    // "C2907216",
    // "C2907215",
    // "C484730",
    // "C5346828",
    // "C154739",
    // "C2906982",
    // "C2906861",
    // "C5310818",
    // "C5692997",
    // "C311983",
    // "C7472816",
    // "C724044",
    // "C2930397",
    // "C2933736",
    // "C2933632",
    // "C409117",
    // "C393014",
    // "C191884",
    // "C5189959",
    // "C5189958",
    // "C5189963",
    // "C393013",
    // "C400542",
    // "C88754",
    // "C88832",
    // "C88771",
    // "C88732",
    // "C77350",
    // "C18185754",
    // "C602037",
    // "C1828",
    // "C5375865",
    // "C2933538",
    // "C2907320",
    // "C2930293",
    // "C2907080",
    // "C2907114",
    // "C110255",
    // "C30926",
    // "C5673",
    // "C1705",
    // "C19702",
    // "C91367",
    // "C3647085",
    // "C2836406",
    // "C2906982",
    // "C2904738",
    // "C5274538",
    // "C5274536",
    // "C5274534",
    // "C5274537",
    // "C5274547",
    // "C7419294",
    // "C468278",
    // "C18723595",
    // "C2931398",
    // "C2931397",
    // "C2931395",
    // "C2931394",
    // "C2931393",
    // "C5446692",
    "C431547",
    "C311983",
];

foreach (string code in codes)
{
    await TryInsert(code);
}

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

