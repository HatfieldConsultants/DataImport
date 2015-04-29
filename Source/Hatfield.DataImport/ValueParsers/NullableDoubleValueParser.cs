﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.DataImport.ValueParsers
{
    public class NullableDoubleValueParser : IValueParser
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
                    return Convert.ToDouble(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Can not parse value to double");
                }
            }

        }
    }
}
