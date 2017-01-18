using System;

namespace SE
{
    public static class StatisticsCalculator
    {
        public static bool TryCalculateOnePass(this double[] array, out double mean, out double variance, out double stdDev)
        {
            var n = array.Length;

            if (n == 0)
            {
                mean = variance = stdDev = 0;
                return false;
            }

            double sum = 0;
            double sumSquared = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                sumSquared += array[i] * array[i];
            }

            mean = sum / n;
            variance = sumSquared / n - mean * mean;
            stdDev = Math.Sqrt(variance);

            return true;
        }

        public static bool TryCalculateTwoPass(this double[] array, out double mean, out double variance, out double stdDev)
        {
            var n = array.Length;

            if (n == 0)
            {
                mean = variance = stdDev = 0;
                return false;
            }

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
            }

            mean = sum / n;

            double sumDeltaSquared = 0;
            for (int i = 0; i < n; i++)
            {
                double delta = array[i] - mean;
                sumDeltaSquared += delta * delta;
            }

            variance = sumDeltaSquared / n;
            stdDev = Math.Sqrt(variance);

            return true; 
        }
    }
}
