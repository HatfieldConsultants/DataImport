using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport
{
    public interface IDataImporter
    {
        bool IsDataSourceSupported(IDataSource dataSource);
        IExtractedDataset Extract(IDataSource dataSource);
        IEnumerable<ICriteria> AllCriterias { get; }
        IEnumerable<IExtractConfiguration> ExtractConfigurations { get; }
    }
}
