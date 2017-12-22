using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Scrape
{
    public class InternetScraperOldTech : IInternetScraper
    {
        public async Task<string> Scrape(Uri uri)
        {
            using (var client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(uri);
            }
        }
    }
}
