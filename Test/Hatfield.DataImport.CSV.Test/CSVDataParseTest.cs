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
        private string _csvDataFilePath;
        private string _datDataFilePath;
        private string[][] _rows;
        IDataSourceLocation dataSourceLocation;
        IDataToImport dataToImport;


        [TestFixtureSetUp]
        public void Setup()
        {
            _csvDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CSV_15min.csv");
            _datDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");           
        }

        [Test]
        public void CSVDataToImportTest()
        {
            var dataSource = new CSVDataSource(_csvDataFilePath);
            dataSourceLocation = new OtherDataSourceLocation();
            dataToImport = dataSource.FetchData();
            var parser = new CellParser();
            AssertData(parser, dataToImport, dataSourceLocation);
        }

        [Test]
        public void CSVDataSourceLocationTest()
        {
            dataSourceLocation = new CSVDataSourceLocation(5, 4);
            dataToImport = new OtherDataToImport();
            var parser = new CellParser();
            AssertData(parser, dataToImport, dataSourceLocation);
        }

        [Test]
        public void CSVParseTestSuccess()
        {
            var dataSource = new CSVDataSource(_csvDataFilePath);
            var dataSourceLocation = new CSVDataSourceLocation(5, 3);
            dataToImport = dataSource.FetchData();
            var parser = new CellParser();
            AssertParserSuccess(parser, dataToImport, dataSourceLocation);
        }

        [Test]
        public void CSVParseTestFailure()
        {
            var dataSource = new CSVDataSource(_csvDataFilePath);
            var dataSourceLocation = new CSVDataSourceLocation(12000, 1);
            dataToImport = dataSource.FetchData();
            var parser = new CellParser();
            AssertParserFail(parser, dataToImport, dataSourceLocation);
        }

        
        private void AssertData(CellParser parser, IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
        {
            var parseResult = parser.Parse<CSVDataSource>(dataToImport, dataSourceLocation);

            Assert.NotNull(parseResult);
            Assert.AreEqual(parseResult.Level, ResultLevel.FATAL);
        }

        
        private void AssertParserSuccess(CellParser parser, IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
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
            public OtherDataSourceLocation()
            {

            }
        }

        //test implementation
        public class OtherDataToImport : IDataToImport
        {
            //Jagged array
            private string[][] _rows;

            public OtherDataToImport()
            {
               
            }

            public object Data
            {
                get { return _rows; }
            }
        }

    }
}
