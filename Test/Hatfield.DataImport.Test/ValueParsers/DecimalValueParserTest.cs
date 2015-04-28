using Hatfield.DataImport.ValueParsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class DecimalValueParserTest
    {
        static object[] testCases = new object[] { 
            new object[]{
                "1234.34345345345",
                1234.34345345345m
            },
            new object[]{
                "444.66",
                444.66m
            },
            new object[]{
                "456346.787575",
                456346.787575m
            }
        };

        [Test]
        [TestCaseSource("testCases")]
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var decimalValueParser = new DecimalValueParser();

            var parsedValue = decimalValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException), "Can not parse null value to datetime")]
        [TestCase("Hello World", typeof(FormatException), "Can not parse value to datetime")]
        public void AssertParseFailTest(string valueToParse, Type expectionType, string exceptionMessage)
        {
            var decimalValueParser = new DecimalValueParser();

            Assert.Throws(expectionType, () => decimalValueParser.Parse(valueToParse), exceptionMessage);
        }
    }
}
