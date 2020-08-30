using System;

namespace SCGCommon
{
    public static class ShortDigit
    {
        public enum AlomarDigitType
        {
            K = 3,
            M = 6,
            B = 9,
        }

        public static void GetParameters(long val, AlomarDigitType maxDigitLength, out Parameters args)
        {
            args.shortDigit = (int)maxDigitLength;
            args.sign = Enum.GetName(typeof(AlomarDigitType), maxDigitLength);

            var shortTypes = Enum.GetValues(maxDigitLength.GetType());
            int currentDigitLength;

            for (int i = 0; i < shortTypes.Length; ++i)
            {
                currentDigitLength = (int)shortTypes.GetValue(i);

                if (val >= Math.Pow(10, currentDigitLength) && (int)maxDigitLength >= currentDigitLength)
                {
                    args.shortDigit = currentDigitLength;
                    args.sign = Enum.GetName(typeof(AlomarDigitType), currentDigitLength);
                }
            }
        }
    }
}