using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneratorTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethod()
        {
            var n = 1000000;
            var a = 65;
            var b = 8921;

            var aResult = new List<double>();
            var bResult = new List<double>();

            Generator.Program.GenerateData(a, b, n, aResult, bResult);

            var equalLastNumber = 0;

            equalLastNumber = Generator.Program.CalculateByLastNumberBits(n, aResult, bResult, equalLastNumber);

            Assert.AreEqual(equalLastNumber, 3868);
        }
    }
}
