using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport.ValueParsers
{
    public class DecimalValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot parse null value to Decimal");
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Cannot parse null value to Decimal");
                }
            }
        }
    }
}
