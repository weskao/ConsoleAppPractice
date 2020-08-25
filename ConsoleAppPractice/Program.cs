using System;
using ConsoleAppPractice.Extensions;

namespace ConsoleAppPractice
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var numberArrayLong = new long[] { 1, 999999999, 1000000000, 1200000000 };
            var numberArrayInt = new int[] { 1, 999999999, 1000000000, 1200000000 };

            PrintArray(numberArrayLong);
            PrintArray(numberArrayInt);
        }

        private static void PrintArray<long>(long[] numberArrayLong)
        {
            foreach (var number in numberArrayLong)
            {
                Console.WriteLine(number.ToLimitCredit());
            }

            Console.ReadKey();
        }
    }
}