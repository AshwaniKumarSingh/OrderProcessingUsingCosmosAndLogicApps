using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IPM.POC.NunitTesting
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestDemo()
        {
          //  Warn.If("abc", Is.Not.EqualTo("abcd"));

            Warn.If(() => "abc", Is.Not.EqualTo("ABC"));

        }
    }
}
