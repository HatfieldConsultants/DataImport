using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.DataImport;

namespace Hatfield.DataImport.Test.ValueAssigners
{
    [TestFixture]
    public class SimpleValueAssignerTest
    {
        
    }

    internal class SimpleValueAssignerRootClass
    {
        public string RootName { get; set; }
        public int RootValue { get; set; }
        public SimpleValueAssignerChildClass Child { get; set; }
    }

    internal class SimpleValueAssignerChildClass
    {
        public string ChildName { get; set; }
        public int ChildValue { get; set; }
    }
}
