using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoFinalCSharp.Features.Scrape;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacaoFinalCSharp.Test.Features.Scrape
{
    [TestClass]
    public class FileSystemScraperTest
    {
        [TestMethod]
        public async Task Scrape_EmptyTestFile_Equal()
        {
            //Arrange
            var fileSystemScraper = new FileSystemScraper();
            //need test file to have "Copy to Output Directory" to not be "Do not copy"
            var uri = new Uri($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}/Features/Scrape/InputTestFiles/JsonEmptyFile.json");

            //Act
            var actual = await fileSystemScraper.Scrape(uri);

            //Assert
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Scrape_SmallFile_Equal()
        {
            //Arrange
            var fileSystemScraper = new FileSystemScraper();
            //need test file to have "Copy to Output Directory" to not be "Do not copy"
            var uri = new Uri($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}/Features/Scrape/InputTestFiles/JsonCountriesSmallFile.json");

            //Act
            var actual = await fileSystemScraper.Scrape(uri);

            //Assert
            const string expected =
                "[\r\n  {\r\n    \"name\": \"Afghanistan\",\r\n    \"code\": \"AF\"\r\n  },\r\n  {\r\n    \"name\": \"Albania\",\r\n    \"code\": \"AL\"\r\n  },\r\n  {\r\n    \"name\": \"Algeria\",\r\n    \"code\": \"DZ\"\r\n  },\r\n  {\r\n    \"name\": \"American Samoa\",\r\n    \"code\": \"AS\"\r\n  }\r\n]";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task Scrape_WrongFileName_FileNotFoundExceptionThrown()
        {
            //Arrange
            var fileSystemScraper = new FileSystemScraper();
            var uri = new Uri($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}/Features/Scrape/InputTestFiles/WrongFileName.json");

            //Act
            await fileSystemScraper.Scrape(uri);

            //Assert => ExpectedException Annotation
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public async Task Scrape_WrongDirectory_DirectoryNotFoundExceptionThrown()
        {
            //Arrange
            var fileSystemScraper = new FileSystemScraper();
            var uri = new Uri($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}/WrongDirectory/Scrape/InputTestFiles/WrongFileName.json");

            //Act
            await fileSystemScraper.Scrape(uri);

            //Assert => ExpectedException Annotation
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public async Task Scrape_InternetPath_DirectoryNotFoundExceptionThrown()
        {
            //Arrange
            var fileSystemScraper = new FileSystemScraper();
            var uri = new Uri("http://easyautocomplete.com/resources/countries.json");

            //Act
            await fileSystemScraper.Scrape(uri);

            //Assert => ExpectedException Annotation
        }
    }
}
