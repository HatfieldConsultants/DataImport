using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport.ValueParsers
{
    public class NullableFloatValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return Convert.ToSingle(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Cannot parse null value to Float");
                }
            }
        }
    }
}
