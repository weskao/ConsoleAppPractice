using ConsoleAppPractice.TestCaseThree;
using NUnit.Framework;

namespace ConsoleAppPractice.Tests
{
    public class NumberExtensionTests
    {
        [Test]
        public void TestMethod()
        {
            int number = 123456789;
            // long number2 = 123456789123123123;

            var limitDigitLength = 9;
            var maxDigitSign = DigitSign.M;

            var convertedResult = number.ToLimitCredit(limitDigitLength, maxDigitSign);
            Assert.AreEqual("123,456,789", convertedResult);
        }
    }
}