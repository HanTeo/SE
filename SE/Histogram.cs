using System;
using System.Linq;

namespace SE
{
    public class Histogram
    {
        private int[] _freq;
        private double _start;
        private double _end;
        private int _interval;

        public Histogram(double start, double end, int buckets)
        {
            if (_start < _end)
            {
                throw new ArgumentOutOfRangeException($"End must be greater than start");
            }

            _start = start;
            _end = end;
            _interval = (int)(end - start) / buckets;
            _freq = Enumerable.Repeat(0, buckets).ToArray();
        }

        public void Add(double number)
        {
            if (number < _start || number > _end)
            {
                throw new ArgumentOutOfRangeException($"Number is out of range {_start}..{_end}");
            }

            var i = (int)number / _interval;
            _freq[i]++;
        }

        public void Add(double[] numbers)
        {
            foreach (var n in numbers)
                Add(n);
        }

        public int[] DataPoints { get { return _freq; } }
    }
}
