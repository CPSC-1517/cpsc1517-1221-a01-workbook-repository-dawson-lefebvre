using NHLSystemClassLibrary;
using System.Runtime.CompilerServices;

namespace NHLSystemTestProject
{
    [TestClass]
    public class CanadianIncomeTaxManagerTest
    {
        [TestMethod]
        public void LineNumberTest()
        {
            CanadianIncomeTaxManager test = new CanadianIncomeTaxManager();
            List<String> testList= test.LoadFromCSVFile(@"../../../data/CanadianPersonalIncomeTaxRates.csv");
            Assert.AreEqual(439, testList.Count);
        }
    }
}