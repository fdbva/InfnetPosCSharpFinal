using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Country
{
    public interface ICountryService
    {
        Task<IDictionary<string, string>> GetCountriesAndCodes();
        Task<IDictionary<string, string>> GetCountriesAndCodes(string sourcePath);
    }
}
