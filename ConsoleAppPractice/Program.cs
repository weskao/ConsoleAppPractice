using ConsoleAppPractice.Extensions;
using System;
using System.Linq;

namespace ConsoleAppPractice
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var numberArrayLong = new long[] { 1, 999999999, 1000000000, 1200000000, (long)Math.Pow(10, 12), (long)Math.Pow(10, 12) + 12345 };
            var numberArrayInt = new int[] { 1, 999999999, 1000000000, 1200000000, (int)Math.Pow(10, 12), (int)Math.Pow(10, 12) + 12345 };
            var numberArrayString = new string[] { "2", "999999999", "1000000000", "1200000000" };

            PrintArray(numberArrayLong);
            PrintArray(numberArrayInt);
            PrintArray(numberArrayString);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void PrintArray<T>(T[] numberArray)
        {
            Console.WriteLine($"Current array type = {typeof(T)}[]");

            foreach (var number in numberArray)
            {
                IConvertible newNumber = null;

                if (typeof(T) == typeof(int))
                {
                    newNumber = Convert.ToInt32(number);
                    Console.WriteLine(((int)newNumber).ToLimitCredit());
                }
                else if (typeof(T) == typeof(long))
                {
                    newNumber = Convert.ToInt64(number);
                    Console.WriteLine(((long)newNumber).ToLimitCredit());
                }
                else
                {
                    Console.WriteLine(number);
                }
            }

            Console.WriteLine("=============");
        }
    }

    public class MyNewClass
    {
        private string _convertedNumber => 5.ToLimitCreditNew();
    }

    public class MyClass
    {
        private readonly long _intNumber = 5;
        private readonly long _longNumber = 999;
        private string ConvertedIntNumber => _intNumber.ToLimitCreditNew();
        private string ConvertedLongNumber => _longNumber.ToLimitCreditNew();

        public void MyMethod()
        {
            var testString = new MyStruct().ToLimitCreditNew();
            Console.WriteLine(testString);
        }
    }

    public struct MyStruct
    {
        public string name;
    }
}