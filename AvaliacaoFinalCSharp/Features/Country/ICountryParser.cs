using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Country
{
    public interface ICountryParser
    {
        Dictionary<string, string> Parse(string textFromSource);
    }
}
