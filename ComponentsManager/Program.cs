// See https://aka.ms/new-console-template for more information

using ComponentsManager.Infrastructure.Network.DTOs;
using ComponentsManager.Infrastructure.Network.Repositories;

Console.WriteLine("Hello, I'm your Components Manager!");
LCSCRepository lcscRepository = new LCSCRepository();
LCSCResultNetDTO? lcscResultNetDto = await lcscRepository.GetPartAsync("555C5265");
if (lcscResultNetDto is not null)
{
    Console.WriteLine(lcscResultNetDto.EncapStandard);
}
else
{
    Console.WriteLine("Not found");
}