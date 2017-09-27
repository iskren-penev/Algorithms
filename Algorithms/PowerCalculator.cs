namespace Algorithms
{
    using System;

    public class PowerCalculator
    {
        public int Calculate(int _base, int exp)
        {
            if (exp < 0)
            {
                throw new ArgumentException("The exponent cannot be less then 0");
                }
            int result = 1;
            for (int i = 0; i < exp; i++)
            {
                result *= _base;
            }
            return result;
        }
    }
}
