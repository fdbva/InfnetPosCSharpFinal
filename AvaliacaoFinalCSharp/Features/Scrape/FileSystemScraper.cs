using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFinalCSharp.Features.Scrape
{
    public class FileSystemScraper : IFileSystemScraper
    {
        public async Task<string> Scrape(Uri uri)
        {
            //no .net core eu poderia chamar direito File.ReadAllTextAsync(uri.LocalPath)
            using (var reader = new StreamReader(uri.LocalPath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
