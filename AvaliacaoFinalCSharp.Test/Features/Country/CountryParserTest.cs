using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoFinalCSharp.Features.Country;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacaoFinalCSharp.Test.Features.Country
{
    [TestClass]
    public class CountryParserTest
    {
        [TestMethod]
        public void Parse_JsonText_Equal()
        {
            //Arrange
            var countryParser = new CountryParser();
            const string textFromSource = "[\r\n  {\r\n    \"name\": \"Afghanistan\",\r\n    \"code\": \"AF\"\r\n  },\r\n  {\r\n    \"name\": \"Albania\",\r\n    \"code\": \"AL\"\r\n  },\r\n  {\r\n    \"name\": \"Algeria\",\r\n    \"code\": \"DZ\"\r\n  },\r\n  {\r\n    \"name\": \"American Samoa\",\r\n    \"code\": \"AS\"\r\n  }\r\n]";

            //Act
            var actual = countryParser.Parse(textFromSource);

            //Assert
            var expected = new Dictionary<string, string>
            {
                { "Afghanistan", "AF" },
                { "Albania", "AL" },
                { "Algeria", "DZ" },
                { "American Samoa", "AS" },
            };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Parse_JsonLowerCaseText_NotEqual()
        {
            //Arrange
            var countryParser = new CountryParser();
            const string textFromSource = "[\r\n  {\r\n    \"name\": \"afghanistan\",\r\n    \"code\": \"AF\"\r\n  },\r\n  {\r\n    \"name\": \"Albania\",\r\n    \"code\": \"AL\"\r\n  },\r\n  {\r\n    \"name\": \"Algeria\",\r\n    \"code\": \"DZ\"\r\n  },\r\n  {\r\n    \"name\": \"American Samoa\",\r\n    \"code\": \"AS\"\r\n  }\r\n]";

            //Act
            var actual = countryParser.Parse(textFromSource);

            //Assert
            var expected = new Dictionary<string, string>
            {
                { "Afghanistan", "AF" },
                { "Albania", "AL" },
                { "Algeria", "DZ" },
                { "American Samoa", "AS" },
            };
            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_EmptyText_Equal()
        {
            //Arrange
            var countryParser = new CountryParser();
            var textFromSource = string.Empty;

            //Act
            countryParser.Parse(textFromSource);

            //Assert => ExpectedException Annotation
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_WhiteSpaceText_Equal()
        {
            //Arrange
            var countryParser = new CountryParser();
            const string textFromSource = "  ";

            //Act
            countryParser.Parse(textFromSource);

            //Assert => ExpectedException Annotation
        }
    }
}
