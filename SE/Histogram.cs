using System;
using System.Collections.Generic;
using System.Linq;

namespace SE
{
    public struct DataPoint
    {
        public DataPoint(string label, int count)
        {
            Label = label;
            Count = count;
        }

        public string Label { get; }

        public int Count { get; }

        public override string ToString()
        {
            return $"| {Label,14} | {Count,6} |";
        }
    }

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

        public int[] Frequencies { get { return _freq; } }

        public IEnumerable<DataPoint> DataPoints
        {
            get
            {
                var from = 0;    
                foreach(var f in Frequencies)
                {
                    var to = from + _interval;
                    yield return new DataPoint($"{from,3} .. {to,3}", f);
                    from = to;
                }
            }
        }
    }
}
