using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Scrape
{
    public interface IScrapeService
    {
        Task<string> ScrapeAsync(string sourcePath);
    }
}
