using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoFinalCSharp.Features.Country;
using AvaliacaoFinalCSharp.Infrastructure.IoC;
using Newtonsoft.Json;
using SimpleInjector;

namespace AvaliacaoFinalCSharp
{
    internal static class Program
    {
        private static Container _container;
        private static void Main()
        {
            _container = new InversionOfControl().Configure();
            var countryService = _container.GetInstance<ICountryService>();

            //no .net core o main poderia ser async, possibilitando o uso do await aqui
            var countriesAndCodes = countryService.GetCountriesAndCodes($"http://easyautocomplete.com/resources/countries.json").Result;

            //não faz parte da refatoração
            foreach (var country in countriesAndCodes)
            {
                Console.WriteLine($"{country.Key} : {country.Value}");
            }
            Console.ReadLine();
        }
    }
}
