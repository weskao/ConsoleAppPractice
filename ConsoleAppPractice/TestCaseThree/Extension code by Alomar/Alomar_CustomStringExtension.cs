using System;
using SCGCommon;

namespace ConsoleAppPractice.TestCaseThree.Extension_code_by_Alomar
{
    public static class CustomStringExtension
    {
        public static string ToLimitCreditFromAlomar(this object val,
            int limitDigitLength = 9,
            ShortDigit.AlomarDigitType shortDigitAlomarDigitType = ShortDigit.AlomarDigitType.M)
        {
            if (!(val is int || val is long || val is double))
            {
                // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", val.GetType(),
                //     System.Reflection.MethodBase.GetCurrentMethod()));

                return string.Empty;
            }

            var limit = Math.Pow(10, limitDigitLength);
            var convertedValue = Convert.ToInt64(val);

            return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(shortDigitAlomarDigitType) : convertedValue.ToCredit();
        }

        public static string ToShorterFloorNumber(this long val, ShortDigit.AlomarDigitType shortDigitAlomarDigitType)
        {
            Parameters parameters;
            ShortDigit.GetParameters(val, shortDigitAlomarDigitType, out parameters);

            var maxDigitSingValue = Convert.ToInt64(Math.Pow(10, parameters.shortDigit));

            if (val >= maxDigitSingValue)
            {
                return string.Format("{0}{1}", (val / maxDigitSingValue).ToCredit(), parameters.sign);
            }

            return val.ToCredit();
        }
    }
}