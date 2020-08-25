namespace ConsoleAppPractice
{
    public struct Triple<T1, T2, T3>
    {
        public T1 Limit { get; set; }
        public T2 Divisor { get; set; }
        public T3 Sign { get; set; }

        // public Triple(X x, Y y, Z z)
        // {
        //     Limit = x;
        //     Divisor = y;
        //     Sign = z;
        // }
    }
}