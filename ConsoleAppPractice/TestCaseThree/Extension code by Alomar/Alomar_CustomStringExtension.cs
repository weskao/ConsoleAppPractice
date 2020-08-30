using System;
using SCGCommon;

namespace ConsoleAppPractice.TestCaseThree.Extension_code_by_Alomar
{
    public static class CustomStringExtension
    {
        public static string ToLimitCreditFromAlomar(this object val,
            int limitDigitLength = 9,
            ShortDigit.Type shortDigitType = ShortDigit.Type.M)
        {
            if (!(val is int || val is long || val is double))
            {
                // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", val.GetType(),
                //     System.Reflection.MethodBase.GetCurrentMethod()));

                return string.Empty;
            }

            var limit = Math.Pow(10, limitDigitLength);
            var convertedValue = Convert.ToInt64(val);

            return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(shortDigitType) : convertedValue.ToCredit();
        }

        public static string ToShorterFloorNumber(this long val, ShortDigit.Type shortDigitType)
        {
            Parameters parameters;
            ShortDigit.GetParameters(val, shortDigitType, out parameters);

            var limit = Convert.ToInt64(Math.Pow(10, parameters.shortDigit));

            if (val >= limit)
            {
                return string.Format("{0}{1}", (val / limit).ToCredit(), parameters.sign);
            }

            return val.ToCredit();
        }
    }
}