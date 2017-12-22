using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AvaliacaoFinalCSharp.Features.Country
{
    public class CountryParser : ICountryParser
    {
        public Dictionary<string, string> Parse(string textFromSource)
        {
            //cpu bound, no reason to async
            return JsonConvert.DeserializeObject<List<CountryModel>>(textFromSource)
                .ToDictionary(x => x.Name, y => y.Code);
        }
    }
}
