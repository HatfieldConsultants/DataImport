using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;
using Hatfield.DataImport.CSV.Parsers;

namespace Hatfield.DataImport.CSV.Test
{
    [TestFixture]
    public class CSVDataParseTest
    {
        private string[][] _rows;
        OtherDataToImport dataToImport;
        CSVDataSourceLocation csvDataSourceLocation;
        CSVDataToImport csvDataToImport;
        OtherDataSourceLocation dataSourceLocation;

        [TestFixtureSetUp]
        public void Setup()
        {
            _rows = new string[20][];
            dataToImport = new OtherDataToImport(_rows);
            csvDataSourceLocation = new CSVDataSourceLocation(5, 4);
            dataSourceLocation = new OtherDataSourceLocation(5, 4);
            csvDataToImport = new CSVDataToImport(_rows);
        }

        [Test]
        public void CSVDataToImportTest()
        {                     
            var parser = new CellParser(); 
            AssertData(parser, dataToImport, dataSourceLocation);
        }

        [Test]
        public void CSVDataSourceLocationParseTest()
        {
            var parser = new CellParser();
            AssertData(parser, csvDataToImport, csvDataSourceLocation);
        }

        [Test]
        public void CSVParseTestSuccess()
        {
            var dataToImport = new CSVDataToImport(_rows);
            var dataSourceLocation = new CSVDataSourceLocation(0, 0);
            var parser = new CellParser();
            AssertParseResultSuccess(parser, dataToImport, dataSourceLocation);
        }

        [Test]
        public void CSVParseTestFailure()
        {
            var parser = new CellParser();
            AssertParserFail(parser, dataToImport, dataSourceLocation);
        }

        
        private void AssertData(CellParser parser, IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
        {
            var parseResult = parser.Parse<CSVDataSource>(dataToImport, dataSourceLocation);

            Assert.NotNull(parseResult);
            Assert.AreEqual(parseResult.Level, ResultLevel.FATAL);
        }

        
        private void AssertParseResultSuccess(CellParser parser, IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
        {
            var parseResult = parser.Parse<CSVDataSource>(dataToImport, dataSourceLocation);

            Assert.NotNull(parseResult);
            Assert.AreEqual(parseResult.Message, "Parsing value successfully");
        }

        private void AssertParserFail(CellParser parser, IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
        {
            var parseResult = parser.Parse<CSVDataSource>(dataToImport, dataSourceLocation);

            Assert.NotNull(parseResult);
            Assert.AreEqual(parseResult.Message, "Index is out of range");
        }

        //test implementation
        public class OtherDataSourceLocation : IDataSourceLocation
        {
            private int _row;
            private int _column;

            public OtherDataSourceLocation(int row, int column)
            {
                _row = row;
                _column = column;
            }

            public int Row
            {
                get
                {
                    return _row;
                }
            }

            public int Column
            {
                get
                {
                    return _column;
                }
            }
        }
        //test implementation
        public class OtherDataToImport : IDataToImport
        {
            //Jagged array
            private string[][] _rows;

            public OtherDataToImport(string[][] rows)
            {
                _rows = rows;
            }

            public object Data
            {
                get { return _rows; }
            }
        }

    }
}
