using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoFinalCSharp.Features.Scrape;
using Newtonsoft.Json;

namespace AvaliacaoFinalCSharp.Features.Country
{
    public class CountryService : ICountryService
    {
        private const string DefaultCountryService = "http://easyautocomplete.com/resources/countries.json";
        private readonly IScrapeService _scrapeService;
        private readonly ICountryParser _countryParser;

        public CountryService(IScrapeService scrapeService, ICountryParser countryParser)
        {
            _scrapeService = scrapeService;
            _countryParser = countryParser;
        }

        public Task<IDictionary<string, string>> GetCountriesAndCodes()
        {
            return GetCountriesAndCodes(DefaultCountryService);
        }

        public async Task<IDictionary<string, string>> GetCountriesAndCodes(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
                return new Dictionary<string, string>();
            var textFromSource = await _scrapeService.ScrapeAsync(sourcePath);
            var countries = _countryParser.Parse(textFromSource);
            return countries;
        }
    }
}
