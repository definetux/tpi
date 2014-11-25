using System;
using System.Linq;

namespace Lab1
{
    public class ArrayProcessor
    {
        public double[] SortAndFilter(double[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a", "Array not be null");
            }
            if (a.Length == 0)
            {
                throw new ArgumentException("Empty array", "a");
            }

            var result = new double[a.Length + 3];
            var sum = a.Sum();
            var difference = a[0];

            for (var i = 1; i < a.Length; i++)
            {
                difference -= a[i];
            }
            var average = sum/a.Length;

            Array.Copy(a, result, a.Length);
            result[a.Length] = Math.Round(sum, 2);
            result[a.Length + 1] = Math.Round(difference, 2);
            result[a.Length + 2] = Math.Round(average, 2);

            return result.OrderByDescending(s => s).Distinct().ToArray();
        }
    }
}