using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppPractice.TestCaseThree.UserDefinedClass;

namespace ConsoleAppPractice.TestCaseThree
{
    public static class NumberExtension
    {
        public static string ToLimitCredit<T>(this T val, int limitDigitLength = 9,
            DigitSign maxDigitSign = DigitSign.B) where T : struct
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                var limit = Math.Pow(10, limitDigitLength);
                var convertedValue = Convert.ToInt64(val);

                return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(limitDigitLength, maxDigitSign) : convertedValue.ToCredit();
            }

            // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", typeof(T),
            //     System.Reflection.MethodBase.GetCurrentMethod()));

            return "";
        }

        private static string ToShorterFloorNumber(this long val, int limitDigitLength, DigitSign maxDigitSign)
        {
            var valueLength = val.ToString().Length;

            var digitMappings = new List<DigitMapping>()
            {
                new DigitMapping(){Sign = DigitSign.B, DigitLength = 9},
                new DigitMapping(){Sign = DigitSign.M, DigitLength = 6},
                new DigitMapping(){Sign = DigitSign.K, DigitLength = 3}
            };

            var step1MinDigitMapping = digitMappings.Where(x =>
            {
                var lengthLowerThanMaxDigitSign = x.DigitLength <= (int)maxDigitSign;
                return (valueLength - x.DigitLength) <= limitDigitLength && lengthLowerThanMaxDigitSign;
            }).Select(x => x);

            if (!step1MinDigitMapping.Any())
            {
                var divisor = (long)Math.Pow(10, (int)maxDigitSign);
                return string.Format("{0}{1}", (val / divisor).ToCredit(), maxDigitSign);
            }

            var step2MinDigitMapping = step1MinDigitMapping.Aggregate((biggerDigitMapping, smallerDigitMapping) => (biggerDigitMapping.DigitLength > smallerDigitMapping.DigitLength ? smallerDigitMapping : null)); ;

            if (step2MinDigitMapping != null)
            {
                var divisor = (long)Math.Pow(10, step2MinDigitMapping.DigitLength);

                return string.Format("{0}{1}", (val / divisor).ToCredit(), step2MinDigitMapping.Sign);
            }
            else
            {
                return val.ToCredit();
            }

            // old code
            var digitFormatList = new List<DigitFormat>()
            {
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength + 6), Value = Math.Pow(10, (int)DigitSign.B), Sign = DigitSign.B},
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength + 3), Value = Math.Pow(10, (int)DigitSign.M), Sign = DigitSign.M},
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength), Value = Math.Pow(10, (int)DigitSign.K), Sign = DigitSign.K},
            };

            foreach (var digitFormat in GetLowerOrEqualThanMaxDigitFormatList(maxDigitSign, false, digitFormatList))
            {
                if (limitDigitLength >= (int)digitFormat.Sign)

                    if (val >= digitFormat.Limit && val >= digitFormat.Value)
                    {
                        return string.Format("{0}{1}", (val / (long)digitFormat.Value).ToCredit(), digitFormat.Sign);
                    }
            }

            return val.ToCredit();
        }

        private static IOrderedEnumerable<DigitFormat> GetLowerOrEqualThanMaxDigitFormatList(DigitSign maxDigitSign, bool isOrderByAsc, List<DigitFormat> digitFormatList)
        {
            return digitFormatList.Where(x => (int)x.Sign <= (int)maxDigitSign).OrderBy(x => isOrderByAsc ? x.Value : 0);
        }

        #region Previous version

        public static string ToCredit(this long number)
        {
            return string.Format("{0:N0}", number); // 1,002,395,000
        }

        public static string ToLimitCredit<T>(this T val, int limitDigitLength = 9, int minDigitLength = 6,
            DigitSign maxDigitSign = DigitSign.B, bool isOrderByAsc = false) where T : struct
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                var limit = Math.Pow(10, limitDigitLength);
                var convertedValue = Convert.ToInt64(val);

                return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(minDigitLength, maxDigitSign) : convertedValue.ToCredit();
            }
            else
            {
                // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", typeof(T),
                //     System.Reflection.MethodBase.GetCurrentMethod()));
            }

            return "";
        }

        public static string ToShorterFloorNumberOld(this long val, int minDigitLength, DigitSign maxDigitSign, bool isOrderByAsc)
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

        #endregion Previous version
    }
}