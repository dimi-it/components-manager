using ComponentsManager.Infrastructure.Databases.Const;
using ComponentsManager.Infrastructure.Databases.DTOs;
using ComponentsManager.Infrastructure.Databases.Repositories;
using Spectre.Console;

namespace ConsoleApp
{
    public class Program
    {
        private static string connectionString = "mongodb://mongo_user:mongo_pswd@localhost:27017/";
        private static string dbName = "componentsDb";
        private static DistributorPartDbRepository _repository;
        
        public static async Task Main()
        {
            _repository = new DistributorPartDbRepository(new MongoConnection(connectionString, dbName));
                
            List<int> categories = ((int[])Enum.GetValues(typeof(TopLevelCategory))).ToList();
            categories.Remove(0);
            while (true)
            {
                TopLevelCategory category = (TopLevelCategory)DisplayCategoryChoices<TopLevelCategory>(categories);
                AnsiConsole.MarkupLine($"[bold]{category.ToString()}[/]");
                string footprint = await DisplayFootprintChoices(category);
                if (footprint.Equals("Back"))
                {
                    continue;
                }

                string result = await DisplayComponentsChoices(category, footprint);
            }
        }

        private static int DisplayCategoryChoices<T>(IEnumerable<int> categories)
        {
            int category = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("Choose a [bold]Category[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .UseConverter(category => ((T)(object)category).ToString())
                    .AddChoices(categories));
            return category;
        }

        private static async Task<string> DisplayFootprintChoices(TopLevelCategory topLevelCategory)
        {
            List<DistributorPartDbDTO> parts = await _repository.GetAllByTopCategoryAsync(topLevelCategory);
            List<string> footprints = parts
                .Select(part => part.Parameters
                    .Where(param => param.Name == ParameterEnum.Footprint)
                    .Select(param => param.ValueString)
                    .First())
                .Distinct()
                .ToList();
            footprints.Add("Back");
            string footprint = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a [bold]Footprint[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
                    .AddChoices(footprints));
            return footprint;
        }
        
        private static async Task<string> DisplayComponentsChoices(TopLevelCategory topLevelCategory, string footprint)
        {
            ParameterEnum paramName;
            if (topLevelCategory == TopLevelCategory.Resistor)
            {
                paramName = ParameterEnum.Resistance;
            }
            else if (topLevelCategory == TopLevelCategory.Capacitor)
            {
                paramName = ParameterEnum.Capacitance;
            }
            else
            {
                throw new NotImplementedException();
            }

            List<DistributorPartDbDTO> parts = await _repository.GetAllByTopCategoryAsync(topLevelCategory);
            parts = parts
                .Where(p => p.Parameters
                                .Where(p => p.Name == ParameterEnum.Footprint)
                                .Select(p => p.ValueString)
                                .First()
                            == footprint)
                .ToList();
            List<string> partsChoices = parts
                .Select(p => $"{p.VendorProductCode}  {p.Parameters
                    .Where(p => p.Name == paramName)
                    .Select(p => p.ValueString)
                    .FirstOrDefault() ?? "-"}")
                .ToList();
                
            partsChoices.Add("Back");
            foreach (string choice in partsChoices)
            {
                Console.WriteLine(choice);
            }

            return "";
            // string result = AnsiConsole.Prompt(
            //     new SelectionPrompt<string>()
            //         .Title($"{topLevelCategory.ToString()}[bold]{footprint}[/]?")
            //         .PageSize(10)
            //         .MoreChoicesText("[grey](Move up and down to reveal more)[/]")
            //         .AddChoices(partsChoices));
            // return result;
        }
    }
    
    
}


