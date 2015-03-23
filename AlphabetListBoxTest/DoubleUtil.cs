using System;

namespace AlphabetListBoxTest
{
    internal class DoubleUtil
    {
        // 浮点型的误差
        private const double DoubleDelta = 1E-06;

        public static bool AreEqual(double value1, double value2)
        {
            return (value1 == value2)
            || Math.Abs(value1 - value2) < DoubleDelta;
        }
 
        public static bool GreaterThan(double value1, double value2)
        {
            return ((value1 > value2) && !AreEqual(value1, value2));
        }
 
        public static bool GreaterThanOrEqual(double value1, double value2)
        {
            return (value1 > value2) || AreEqual(value1, value2);
        }
 
        public static bool IsZero(double value)
        {
            return (Math.Abs(value) < DoubleDelta);
        }

        public static bool LessThan(double value1, double value2)
        {
            return ((value1 < value2) && !AreEqual(value1, value2));
        }
 
        public static bool LessThanOrEqual(double value1, double value2)
        {
            return (value1 < value2) || AreEqual(value1, value2);
        }
    }
}
