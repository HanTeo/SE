using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SE.Tests
{
    [TestClass]
    public class StatisticsCalculatorTests
    {
        [TestMethod]
        public void TestStatsOnePass()
        {
            var items = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            double mean;
            double variance;
            double stdDev;
            var pass = items.TryCalculateOnePass(out mean, out variance, out stdDev);

            Assert.IsTrue(pass);
            Assert.AreEqual(3.0, mean);
            Assert.AreEqual(2, variance);
            Assert.AreEqual(1.414, stdDev, 0.001);
        }

        [TestMethod]
        public void TestStatsTwoPass()
        {
            var items = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            double mean;
            double variance;
            double stdDev;
            var pass = items.TryCalculateTwoPass(out mean, out variance, out stdDev);

            Assert.IsTrue(pass);
            Assert.AreEqual(3.0, mean);
            Assert.AreEqual(2, variance);
            Assert.AreEqual(1.414, stdDev, 0.001);
        }

        [TestMethod]
        public void TestStatsOnline()
        {
            var items = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            double mean;
            double variance;
            double stdDev;
            var pass = items.TryCalculateOnline(out mean, out variance, out stdDev);

            Assert.IsTrue(pass);
            Assert.AreEqual(3.0, mean);
            Assert.AreEqual(2.5, variance);
            Assert.AreEqual(1.5811, stdDev, 0.001);
        }
    }
}
