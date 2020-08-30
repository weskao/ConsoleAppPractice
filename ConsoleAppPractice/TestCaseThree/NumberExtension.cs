using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppPractice.TestCaseThree.UserDefinedClass;

namespace ConsoleAppPractice.TestCaseThree
{
    public static class NumberExtension
    {
        public static string ToLimitCredit<T>(this T val, int limitDigitLength = 9,
            DigitSign maxDigitSign = DigitSign.B, bool isOrderByAsc = false) where T : struct
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double))
            {
                var limit = Math.Pow(10, limitDigitLength);
                var convertedValue = Convert.ToInt64(val);

                return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(limitDigitLength, maxDigitSign, isOrderByAsc) : convertedValue.ToCredit();
            }

            // Debug.LogWarning(string.Format("This type {0} is not support for {1} extension method", typeof(T),
            //     System.Reflection.MethodBase.GetCurrentMethod()));

            return "";
        }

        private static string ToShorterFloorNumber(this long val, int limitDigitLength, DigitSign maxDigitSign, bool isOrderByAsc)
        {
            var valueLength = val.ToString().Length;

            var digitMappings = new List<DigitMapping>()
            {
                new DigitMapping(){Sign = DigitSign.B, DigitLength = 9},
                new DigitMapping(){Sign = DigitSign.M, DigitLength = 6},
                new DigitMapping(){Sign = DigitSign.K, DigitLength = 3}
            };

            var minDigitMapping = digitMappings.Where(x =>
            {
                var lengthLoweThanMaxDigitSign = x.DigitLength <= (int)maxDigitSign;
                return (valueLength - x.DigitLength) <= limitDigitLength && lengthLoweThanMaxDigitSign;
            }).Aggregate((biggerDigitMapping, smallerDigitMapping) => (biggerDigitMapping.DigitLength > smallerDigitMapping.DigitLength ? smallerDigitMapping : null)); ;

            if (minDigitMapping != null)
            {
                var divisor = (long)Math.Pow(10, minDigitMapping.DigitLength);

                return string.Format("{0}{1}", (val / divisor).ToCredit(), minDigitMapping.Sign);
            }
            else
            {
                return val.ToCredit();
            }

            // var minDigitMapping =
            //     digitMappings.Where(x => x.DigitLength <= (int)maxDigitSign)
            //     .
            //
            // {
            //     var lengthLoweThanMaxDigitSign = x.DigitLength <= (int)maxDigitSign;
            //     return (valueLength - x.DigitLength) <= limitDigitLength && lengthLoweThanMaxDigitSign;
            //
            // })?.Aggregate((biggerDigitMapping, smallerDigitMapping) => (biggerDigitMapping.DigitLength > smallerDigitMapping.DigitLength ? smallerDigitMapping : null)); ;

            // var minDigitMapping = digitMappings.Aggregate((biggerDigitMapping, smallerDigitMapping) =>
            //     ((valueLength - smallerDigitMapping.DigitLength) <= limitDigitLength
            //      && smallerDigitMapping.DigitLength <= (int)maxDigitSign
            //      && biggerDigitMapping.DigitLength > smallerDigitMapping.DigitLength ? smallerDigitMapping : null));

            // var max = digitMappings.Max(x => valueLength >= x.DigitLength);
            // var maxMapping = digitMappings.FirstOrDefault(x => valueLength >= x.DigitLength && valueLength >= limitDigitLength);

            // var maxDigitSignLength = (int)maxDigitSign;
            // if (valueLength >= limitDigitLength)
            // {
            // var enumerable = digitMappings.Where(x => x.DigitLength <= maxDigitLength && x.DigitLength <= valueLength).Select(x => x).ToList();
            // var e2 = enumerable.OrderBy(x => x.DigitLength).Select(x => x).ToList();
            // var maxMapping = e2.FirstOrDefault(x => x.DigitLength <= valueLength);
            //
            // if (maxMapping != null && valueLength >= limitDigitLength)
            // {
            //     Debug.Log("not null, return convertedResult");
            //     return string.Format("{0}{1}", (val / (long)Math.Pow(10, maxMapping.DigitLength)).ToCredit(), maxMapping.Sign);
            // }
            // // }
            // Debug.Log("null! return ToCredit();");
            // return val.ToCredit();

            // digitMappings = digitMappings.OrderBy(x => x.DigitLength).ToList();
            //
            // for (var i = 0; i < digitMappings.Count; i++)
            // {
            //     int currentDigitLength2 = digitMappings[i].DigitLength;
            //
            //     if (valueLength >= currentDigitLength2 && maxDigitSignLength >= currentDigitLength2)
            //     {
            //         return string.Format("{0}{1}", (val / (long)Math.Pow(10, digitMappings[i].DigitLength)).ToCredit(), digitMappings[i].Sign);
            //     }
            // }
            //
            // return val.ToCredit();

            // var shortDigit = maxDigitSignLength;
            // // var sign = Enum.GetName(typeof(AlomarDigitType), maxDigitSignLength);
            //
            // int currentDigitLength;
            //
            // for (int i = 0; i < digitMappings.Count; ++i)
            // {
            //     currentDigitLength = digitMappings[i].DigitLength;
            //
            //     if (val >= Math.Pow(10, currentDigitLength) && (int)maxDigitSignLength >= currentDigitLength)
            //     {
            //         shortDigit = currentDigitLength;
            //         // sign = Enum.GetName(typeof(AlomarDigitType), currentDigitLength);
            //
            //         return string.Format("{0}{1}", (val / (long)Math.Pow(10, digitMappings[i].DigitLength)).ToCredit(), digitMappings[i].Sign);
            //     }
            // }
            //
            // return val.ToCredit();

            // var maxMapping = e2.FirstOrDefault(x => x.DigitLength <= valueLength && (valueLength - x.DigitLength) <= maxDigitLength && maxDigitLength < valueLength);
            // .FirstOrDefault(x => x.DigitLength <= valueLength && x.DigitLength <= limitDigitLength);
            //
            // var maxMapping = digitMappings.Where(x => x.DigitLength <= valueLength)
            //     .Max(x => x.DigitLength);

            if (valueLength >= limitDigitLength)
            {
                // var lowerOrEqualThanMaxDigitMapping = digitMappings.Max(x => valueLength >= x.DigitLength);
            }
            // for (var i = 0; i < Enum.GetNames(typeof(DigitFormat)).DigitLength; i++)
            // {
            // var enumerable = digitLengthArray.OrderByDescending(digitLength => digitLength)
            //                               .FirstOrDefault(maxDigitLength => valueLength >= maxDigitLength);

            // way2
            // var digitLengthArray = Enum.GetValues(typeof(DigitFormat)).Cast<int>();
            // var max = digitLengthArray.Max(maxDigitLength => valueLength >= maxDigitLength);
            // if (max != null)
            // {
            // }
            // else
            // {
            //     return val.ToCredit();
            // }

            // if(valueLength >= limitDigitLength &&))
            // }

            var digitFormatList = new List<DigitFormat>()
            {
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength + 6), Value = Math.Pow(10, (int)DigitSign.B), Sign = DigitSign.B},
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength + 3), Value = Math.Pow(10, (int)DigitSign.M), Sign = DigitSign.M},
                new DigitFormat(){Limit = Math.Pow(10, limitDigitLength), Value = Math.Pow(10, (int)DigitSign.K), Sign = DigitSign.K},
            };

            foreach (var digitFormat in GetLowerOrEqualThanMaxDigitFormatList(maxDigitSign, isOrderByAsc, digitFormatList))
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

                return (convertedValue >= limit) ? convertedValue.ToShorterFloorNumber(minDigitLength, maxDigitSign, isOrderByAsc) : convertedValue.ToCredit();
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