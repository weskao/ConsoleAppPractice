﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppPractice.Extensions
{
    public static class DigitExtension
    {
        //////////////
        // public static string ToLimitCredit<T>(this T val)
        // {
        //     if (typeof(T) == typeof(int))
        //     {
        //     }
        //     return "";
        // }

        //////////////
        public static string ToLimitCredit(this long val, long limit = 999999999)
        {
            return (val > limit) ? val.ToShorterFloorNumber() : val.ToCredit();
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

        public static string ToCredit(this long val)
        {
            return $"{val:N0}"; // or use this: return val.ToString("N0");
        }
    }
}