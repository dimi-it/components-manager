// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Network.LCSC;
using ComponentsManager.Infrastructure.Network.LCSC.DTOs;

Console.WriteLine("Hello, I'm your Components Manager!");
LCSCRepository lcscRepository = new LCSCRepository();
LCSCPartNetDTO? lcscResultNetDto = await lcscRepository.GetPartNetAsync("C14445");

if (lcscResultNetDto != null)
{
    DistributorPartDbDTO part = lcscResultNetDto.ToDistributorPartDbDTO();
    Console.WriteLine(part.ToString());
}
else
{
    Console.WriteLine("Not found");
}