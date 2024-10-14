// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Network.LCSC;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;

Console.WriteLine("Hello, I'm your Components Manager!");
LCSCRepository lcscRepository = new LCSCRepository();
string partCode = "C167220";

try
{
    DistributorPartDbDTO? part = await lcscRepository.GetDistributorPartAsync(partCode);
    if (part is not null)
    {
        Console.WriteLine(part.ToString());
    }
    else
    {
        Console.WriteLine("Not found");
    }
}
catch (ArgumentNullException e)
{
    Console.WriteLine(e.Message);
}
