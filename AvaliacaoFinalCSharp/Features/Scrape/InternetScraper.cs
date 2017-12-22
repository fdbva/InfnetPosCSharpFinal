using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Scrape
{
    public class InternetScraper : IInternetScraper
    {
        private readonly HttpClient _httpClient;

        public InternetScraper()
        {
            //reccomendation to use HttpClient without using()
            //https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            _httpClient = new HttpClient();
        }

        public async Task<string> Scrape(Uri uri)
        {
            return await _httpClient.GetStringAsync(uri);
        }

        //recommended not to dispose, research more
        //https://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed
        
#pragma warning disable S125 // Sections of code should not be "commented out"
/*
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            HttpClient.Dispose();
        }

        ~InternetScraper()
        {
            Dispose(false);
        }
        */
    }
#pragma warning restore S125 // Sections of code should not be "commented out"
}
