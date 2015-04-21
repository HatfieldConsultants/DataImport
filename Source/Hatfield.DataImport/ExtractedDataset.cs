using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport
{
    public class ExtractedDataset : IExtractedDataset
    {
        private IEnumerable<IResult> _results;

        public ExtractedDataset()
        {
            _results = new List<IResult>();
        }

        public IEnumerable<object> ExtractedEntities
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsExtractedSuccess
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IResult> AllParsingResults
        {
            get { return _results; }
        }

        public void AddParsingResult(IResult parsingResult)
        {
            ((IList<IResult>)_results).Add(parsingResult);
        }

        public void AddParsingResults(IEnumerable<IResult> parsingResults)
        {
            _results = _results.Concat(parsingResults);
        }
    }
}
