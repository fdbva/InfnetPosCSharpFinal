using AvaliacaoFinalCSharp.Features.Country;
using AvaliacaoFinalCSharp.Features.Scrape;
using SimpleInjector;

namespace AvaliacaoFinalCSharp.Infrastructure.IoC
{
    public class InversionOfControl
    {
        public Container Configure()
        {
            var container = new Container();

            container.Register<ICountryService, CountryService>();
            container.Register<ICountryParser, CountryParser>();
            container.Register<IScrapeService, ScrapeService>();
            container.Register<IFileSystemScraper, FileSystemScraper>();
            container.Register<IInternetScraper, InternetScraper>(Lifestyle.Singleton);

            container.Verify();
            return container;
        }
    }
}
