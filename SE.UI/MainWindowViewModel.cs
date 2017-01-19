using System.Collections.Generic;

namespace SE.UI
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var data = TestDataProvider.GetCsvData(id: "0B-zod47PgWfmZ2ZQWmZRMXVyNXc");

            DataPoints = GetChartData(data);

            Statistics = GetStatsData(data);
        }

        private static IEnumerable<DataPoint> GetChartData(double[] data)
        {
            var hist = new Histogram(start: 0, end: 100, buckets: 10);
            hist.Add(data);

            return hist.DataPoints;
        }

        private static List<StatisticsViewModel> GetStatsData(double[] data)
        {
            var stats = new List<StatisticsViewModel>();
            double mean, variance, stdDev;
            data.TryCalculateOnline(out mean, out variance, out stdDev);
            stats.Add(new StatisticsViewModel { Methodology = "Welford's", Mean = mean, StdDev = stdDev });
            data.TryCalculateOnePass(out mean, out variance, out stdDev);
            stats.Add(new StatisticsViewModel { Methodology = "Single Pass", Mean = mean, StdDev = stdDev });
            data.TryCalculateTwoPass(out mean, out variance, out stdDev);
            stats.Add(new StatisticsViewModel { Methodology = "Two Pass", Mean = mean, StdDev = stdDev });

            return stats;
        }

        public IEnumerable<DataPoint> DataPoints
        {
            get;
        }

        public IEnumerable<StatisticsViewModel> Statistics
        {
            get;
        }
    }
}