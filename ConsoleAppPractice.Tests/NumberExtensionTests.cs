﻿using System;
using ConsoleAppPractice.TestCaseThree;
using NUnit.Framework;

namespace ConsoleAppPractice.Tests
{
    public class NumberExtensionTests
    {
        private string _convertedResult;
        private long _number;

        #region Limit length: 5, Max digit sign: K

        [Test]
        public void NumberLengthLessThanLimitLength_ReturnFullValue()
        {
            GivenNumber(9999);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("9,999");
        }

        [Test]
        public void NumberLengthEqualLimitLength_ReturnFullValue()
        {
            GivenNumber(99999);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("99,999");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLength_Case1_ReturnAbbreviationValueWithK()
        {
            GivenNumber(199999);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("199K");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLength_Case2_ReturnAbbreviationValueWithK()
        {
            GivenNumber(1234567);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("1,234K");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLength_ReturnAbbreviationValueWithK()
        {
            GivenNumber(12345678);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("12,345K");
        }

        [Test]
        public void NumberLengthOverLimitLengthAgain_AlwaysReturnK()
        {
            GivenNumber(123456789);
            GivenLimit(5, DigitSign.K);
            ConvertedResultShouldBe("123,456K");
        }

        #endregion Limit length: 5, Max digit sign: K

        #region Limit length: 5, Max digit sign: M

        [Test]
        public void NumberLengthLessThanLimitLengthMaxDigitSingIsM_ReturnFullValue()
        {
            GivenNumber(9999);
            GivenLimit(5, DigitSign.M);
            ConvertedResultShouldBe("9,999");
        }

        [Test]
        public void NumberLengthEqualLimitLengthMaxDigitSingIsM_ReturnFullValue()
        {
            GivenNumber(99999);
            GivenLimit(5, DigitSign.M);
            ConvertedResultShouldBe("99,999");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLengthMaxDigitSingIsM_Case1_ReturnAbbreviationValueWithK()
        {
            GivenNumber(199999);
            GivenLimit(5, DigitSign.M);
            ConvertedResultShouldBe("199K");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLengthMaxDigitSingIsM_Case2_ReturnAbbreviationValueWithK()
        {
            GivenNumber(1234567);
            GivenLimit(5, DigitSign.M);
            ConvertedResultShouldBe("1,234K");
        }

        [Test]
        public void NumberLengthGreaterThanLimitLengthMaxDigitSingIsM_ReturnAbbreviationValueWithK()
        {
            GivenNumber(12345678);
            GivenLimit(5, DigitSign.M);
            ConvertedResultShouldBe("12,345K");
        }

        #endregion Limit length: 5, Max digit sign: M

        #region #region Limit length: 9, Max digit sign: B

        [Test]
        public void NumberLengthEqualLimitLength_ReturnToFullValue()
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

        #endregion #region Limit length: 9, Max digit sign: B

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