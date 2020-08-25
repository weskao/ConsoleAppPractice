using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
            string result;

            var key = "M";
            var myClass = new MyClass();
            // myClass.Limit = Math.Pow(10, 9);
            // myClass.Divisor = 1000000;

            var myDictionary = new Dictionary<string, MyClass>()
            {
                {"M", new MyClass {Limit = Math.Pow(10,9), Divisor = 1000000}},
                {"k", new MyClass {Limit = Math.Pow(10,6), Divisor = 1000}},
            };

            var myTriple = new List<Triple<double, int, string>>()
            {
                new Triple<double, int, string>(){Limit = Math.Pow(10,9), Divisor = 1000000, Sign = "M"},
                new Triple<double, int, string>(){Limit = Math.Pow(10,6), Divisor = 1000, Sign = "k"}
            };

            ""

            myTriple = myTriple.OrderByDescending(x => x).ToList();
            foreach (var triple in myTriple)
            {
                if (val >= triple.Limit)
                {
                    return (val / triple.Divisor).ToCredit(){ }
                }
            }

            // var myTriple = new Triple<double, int, string>(
            //     Math.Pow(10, 9),
            //     1000000,
            //     "M"
            // );

            if (val >= myClass.Limit)
            {
                result = (val / myClass.Divisor).ToCredit() + key;
            }
            else if (val >= Math.Pow(10, 6))
            {
                result = (val / 1000).ToCredit() + "k";
            }
            else
            {
                result = val.ToCredit();
            }

            return result;
        }

        public static string ToCredit(this long val)
        {
            return $"{val:N0}"; // or use this: return val.ToString("N0");
        }
    }

    public struct Triple<X, Y, Z>
    {
        public X Limit;
        public Y Divisor;
        public Z Sign;

        // public Triple(X x, Y y, Z z)
        // {
        //     Limit = x;
        //     Divisor = y;
        //     Sign = z;
        // }
    }

    public struct MyClass
    {
        public double Limit { get; set; }
        public int Divisor { get; set; }
    }
}