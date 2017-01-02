using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        private static string[] names = { "NASDAQ_MSFT", "NASDAQ_AAPL", "NASDAQ_GOOG" };
        private static List<string> list = new List<string>();
        private static ManualResetEvent ready = new ManualResetEvent(false);
        static void Main(string[] args) {
            foreach (var name in names) {
                GetQuandlDataAsync(name);

            }
            ready.WaitOne();
            DisplayData(list);
            Console.WriteLine("Done");
        }

        private static async void GetQuandlDataAsync(string name) {
            var stockDataTask = Task.Run(() => RetrieveStockData(name));
            var stockData = await stockDataTask;
            var seriesData = Task.Run(() => GetSeries(new List<string>() { stockData }, name));
            var trendData = Task.Run(() => GetTrend(new List<string>() { stockData }, name));
            list.Add(await seriesData);
            list.Add(await trendData);
            if (list.Count == (names.Count() * 2))
                ready.Set();
        }

        private static string RetrieveStockData(string name) {
            Thread.Sleep(1000);
            Console.WriteLine($"{name} stockValues");
            return $"{name} stockValues";
        }

        private static string GetSeries(List<string> stockValues, string name) {
            Thread.Sleep(2000);
            string s = $"{name}";
            foreach (var value in stockValues) {
                s += $" {value}";
            }
            Console.WriteLine(s + " series");
            return s + " series";
        }

        private static string GetTrend(List<string> stockValues, string name) {
            Thread.Sleep(2000);
            string s = $"{name}";
            foreach (var value in stockValues) {
                s += $" {value}";
            }
            Console.WriteLine(s + " trend");
            return s + " trend";
        }

        private static void DisplayData(List<string> seriesList) {
            foreach (var item in seriesList) {
                Console.WriteLine(item);
            }
        }
    }
}
