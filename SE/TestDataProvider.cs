using System;
using System.Net;

namespace SE
{
    public class TestDataProvider
    {
        public static double[] GetCsvData(string id)
        {
            string url = $"https://drive.google.com/uc?export=download&id={id}";

            using (var client = new WebClient())
            {
                var elements = client
                    .DownloadString(url)
                    .Split(',');

                var numbers = Array.ConvertAll(elements, double.Parse);

                return numbers;
            }
        }
    }
}
