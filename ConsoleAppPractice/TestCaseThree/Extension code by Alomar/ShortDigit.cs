using System;

namespace SCGCommon
{
    public static class ShortDigit
    {
        public enum Type
        {
            K = 3,
            M = 6,
            B = 9,
        }

        public static void GetParameters(long val, Type maxDigitLength, out Parameters args)
        {
            args.shortDigit = (int)maxDigitLength;
            args.sign = Enum.GetName(typeof(Type), maxDigitLength);

            var shortTypes = Enum.GetValues(maxDigitLength.GetType());
            int currentDigitLength;

            for (int i = 0; i < shortTypes.Length; ++i)
            {
                currentDigitLength = (int)shortTypes.GetValue(i);

                if (val >= Math.Pow(10, currentDigitLength) && (int)maxDigitLength >= currentDigitLength)
                {
                    args.shortDigit = currentDigitLength;
                    args.sign = Enum.GetName(typeof(Type), currentDigitLength);
                }
            }
        }
    }
}