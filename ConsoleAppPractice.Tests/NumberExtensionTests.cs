using ConsoleAppPractice.TestCaseThree;
using NUnit.Framework;

namespace ConsoleAppPractice.Tests
{
    public class NumberExtensionTests
    {
        private string _convertedResult;
        private int _number;

        [Test]
        public void NumberLengthEqualLimitLength_ReturnToCreditValue()
        {
            GivenNumber(123456789);
            GivenLimit(9, DigitSign.M);
            ConvertedResultShouldBe("123,456,789");
        }

        private void GivenNumber(int number)
        {
            _number = number;
        }

        private void GivenLimit(int limitDigitLength, DigitSign maxDigitSign)
        {
            _convertedResult = _number.ToLimitCredit(limitDigitLength, maxDigitSign);
        }

        private void ConvertedResultShouldBe(string result)
        {
            Assert.AreEqual(result, _convertedResult);
        }
    }
}