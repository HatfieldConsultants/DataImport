using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport
{
    public interface IImporterBuilder
    {
        IDataImporter Build();
    }
}
