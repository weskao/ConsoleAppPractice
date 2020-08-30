using System;
using ConsoleAppPractice.TestCaseThree;
using NUnit.Framework;

namespace ConsoleAppPractice.Tests
{
    public class NumberExtensionTests
    {
        private string _convertedResult;
        private long _number;

        [Test]
        public void NumberLengthEqualLimitLength_ReturnToCreditValue()
        {
            GivenNumber(123456789);
            GivenLimit(9, DigitSign.B);
            ConvertedResultShouldBe("123,456,789");
        }

        [Test]
        public void NumberLengthEqualLimitLength_ReturnAbbreviationValue()
        {
            GivenNumber(123456789);
            GivenLimit(9, DigitSign.M);
            ConvertedResultShouldBe("123,456,789");
        }

        [Test]
        public void NumberLengthGreaterLimitLength_ReturnAbbreviationValueWithK()
        {
            GivenNumber(1234567890);
            GivenLimit(9, DigitSign.B);
            ConvertedResultShouldBe("1,234,567K");
        }

        [Test]
        public void NumberLengthGreaterLimitLength_ReturnAbbreviationValueWithM()
        {
            GivenNumber(1234567890123);
            GivenLimit(9, DigitSign.B);
            ConvertedResultShouldBe("1,234,567M");
        }

        [Test]
        public void NumberLengthGreaterLimitLength_ReturnAbbreviationValueWithB()
        {
            GivenNumber(1234567890123456);
            GivenLimit(9, DigitSign.B);
            ConvertedResultShouldBe("1,234,567B");
        }

        private void GivenNumber<T>(T number)
        {
            _number = Convert.ToInt64(number);
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