using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppPractice.TestCaseThree.UserDefinedClass;

namespace ConsoleAppPractice.TestCaseThree
{
    public static class OldNumberExtension
    {
        // TODO: Change signature
        public static string ToLimitCredit<T>(this T val, int limitDigitLength = 9, int minDigitLength = 6,
            DigitSign maxDigitSign = DigitSign.B, bool isOrderByAsc = false) where T : struct
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                var limit = Math.Pow(10, limitDigitLength);
                var convertedValue = Convert.ToInt64(val);

                return (convertedValue >= limit) ? convertedValue.OldToShorterFloorNumber(minDigitLength, maxDigitSign, isOrderByAsc) : convertedValue.ToCredit();
            }
            else
            {
                // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", typeof(T),
                //     System.Reflection.MethodBase.GetCurrentMethod()));
            }

            return "";
        }

        public static string OldToShorterFloorNumber(this long val, int minDigitLength, DigitSign maxDigitSign, bool isOrderByAsc)
        {
            // minDigitLength = (int)maxDigitSign;

            var limit = Math.Pow(10, minDigitLength); // ex: 10^6
            if (val >= limit)
            {
                // 根據 maxDigitSign 的限制,  Convert to K, B, M 縮寫 => Math.Pow(10, (int)Math.Pow(10, minDigitLength)).ToCredit();
            }
            else
            {
                // return val.ToCredit();
            }

            var maxDigitLength = (int)maxDigitSign;

            var digitFormatMapping = new List<DigitFormat>()
            {
                new DigitFormat(){Limit = Math.Pow(10, minDigitLength + 6), Value = Math.Pow(10, (int)DigitSign.B), Sign = DigitSign.B},
                new DigitFormat(){Limit = Math.Pow(10, minDigitLength + 3), Value = Math.Pow(10, (int)DigitSign.M), Sign = DigitSign.M},
                new DigitFormat(){Limit = Math.Pow(10, minDigitLength), Value = Math.Pow(10, (int)DigitSign.K), Sign = DigitSign.K},
            };

            foreach (var digitFormat in digitFormatMapping.Where(x => (int)x.Sign <= (int)maxDigitSign).OrderBy(x => isOrderByAsc ? x.Limit : 0))
            // foreach (var digitFormat in digitFormatMapping.OrderBy(x => isOrderByAsc ? x.Limit : 0))
            {
                if (val >= digitFormat.Limit)
                {
                    return string.Format("{0}{1}", (val / (long)digitFormat.Value).ToCredit(), digitFormat.Sign);
                }
            }

            return val.ToCredit();
        }
    }
}