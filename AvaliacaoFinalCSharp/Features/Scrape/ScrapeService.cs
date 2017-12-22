using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Scrape
{
    public class ScrapeService : IScrapeService
    {
        private readonly IInternetScraper _internetScraper;
        private readonly IFileSystemScraper _fileSystemScraper;

        public ScrapeService(IInternetScraper internetScraper, IFileSystemScraper fileSystemScraper)
        {
            _internetScraper = internetScraper;
            _fileSystemScraper = fileSystemScraper;
        }

        public async Task<string> ScrapeAsync(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
                return string.Empty;
            var serializedText = string.Empty;
            var uri = new Uri(sourcePath);

            if (uri.Scheme.Equals(Uri.UriSchemeHttp) || uri.Scheme.Equals(Uri.UriSchemeHttps))
            {
                serializedText = await _internetScraper.Scrape(uri);
            }
            else if (uri.IsFile)
            {
                serializedText = await _fileSystemScraper.Scrape(uri);
            }

            return serializedText;
        }
    }
}
