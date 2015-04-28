﻿using System;
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
                return null;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Cannot parse value to Decimal");
                }
            }
        }
    }
}
