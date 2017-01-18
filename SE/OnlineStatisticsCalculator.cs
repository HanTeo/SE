using System;

namespace SE
{
    public class OnlineStatisticsCalculator
    {
        private int _n;
        private double _oldM;
        private double _newM;
        private double _oldS;
        private double _newS;

        public void Clear()
        {
            _n = 0;
        }

        public void Push(double x)
        {
            _n++;

            if (_n == 1)
            {
                _oldM = _newM = x;
                _oldS = 0.0;
            }
            else
            {
                _newM = _oldM + (x - _oldM) / _n;
                _newS = _oldS + (x - _oldM) * (x - _newM);
                _oldM = _newM;
                _oldS = _newS;
            }
        }

        public int NumDataValues()
        {
            return _n;
        }

        public double Mean
        {
            get { return (_n > 0) ? _newM : 0.0; }
        }

        public double Variance
        {
            get { return ((_n > 1) ? _newS / (_n - 1) : 0.0); }
        }

        public double StandardDeviation
        {
            get { return Math.Sqrt(Variance); }
        }
    }
}
