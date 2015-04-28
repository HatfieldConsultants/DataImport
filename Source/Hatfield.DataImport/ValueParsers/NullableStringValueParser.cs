using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport.ValueParsers
{
    public class NullableStringValueParser : IValueParser
    {
        public object Parse(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value.ToString().Trim();
            }
        }
    }
}
