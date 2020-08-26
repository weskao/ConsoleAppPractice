using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppPractice.Extensions
{
    public static class DigitExtension
    {
        public static string ToLimitCreditNew<T>(this T val, long limit = 999999) where T : struct
        {
            // Need to support these type
            // if ((typeof(T) == typeof(double) ||
            //      typeof(T) == typeof(int) ||
            //      typeof(T) == typeof(float) ||
            //      typeof(T) == typeof(decimal) ||
            //      typeof(T) == typeof(long)))
            // {
            //     return $"{val:N0}"; // or use this: return val.ToString("N0");
            // }
            //
            // return "";

            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                var convertedValue = Convert.ToInt64(val);
                return (convertedValue > limit) ? convertedValue.ToShorterFloorNumber() : convertedValue.ToCredit();
            }

            return "";
        }

        public static string ToLimitCredit<T>(this T val, long limit = 999999999)
        {
            var convertedValue = Convert.ToInt64(val);
            return (convertedValue > limit) ? convertedValue.ToShorterFloorNumber() : convertedValue.ToCredit();
        }

        public static string ToShorterFloorNumber(this long val)
        {
            var myTriple = new List<Triple<double, int, string>>()
            {
                new Triple<double, int, string>(){Limit = Math.Pow(10,12), Divisor = 1000000000, Sign = "B"},
                new Triple<double, int, string>(){Limit = Math.Pow(10,9), Divisor = 1000000, Sign = "M"},
                new Triple<double, int, string>(){Limit = Math.Pow(10,6), Divisor = 1000, Sign = "k"}
            };

            foreach (var triple in myTriple.OrderByDescending(x => x.Limit))
            {
                if (val >= triple.Limit)
                {
                    return $"{(val / triple.Divisor).ToCredit()}{triple.Sign}";
                }
            }

            return val.ToCredit();
        }

        public static string ToCredit<T>(this T val) where T : struct
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return $"{val:N0}"; // or use this: return val.ToString("N0");
            }
            else
            {
                return "";
            }
        }
    }
}