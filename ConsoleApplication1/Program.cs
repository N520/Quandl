using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        private static string[] names = { "NASDAQ_MSFT", "NASDAQ_AAPL", "NASDAQ_GOOG" };

        static void Main(string[] args) {
            List<Task<string>> list = new List<Task<string>>();
            foreach (var name in names) {
                var task = Task.Run(() => RetrieveStockData(name));
                var seriesTask = Task.Run(() => GetSeries(new List<string>() { task.Result }, name));
                var trendTask = Task.Run(() => GetTrend(new List<string>() { task.Result }, name));
                list.Add(seriesTask); list.Add(trendTask);
            }
            Task.WaitAll(list.ToArray());
            Console.WriteLine("Done");
            DisplayData(list.Select(item => item.Result).ToList());
        }

        private static string RetrieveStockData(string name) {
            Console.WriteLine($"{name} stockValues");
            return $"{name} stockValues";
        }

        private static string GetSeries(List<string> stockValues, string name) {
            string s = $"{name}";
            foreach (var value in stockValues) {
                s += $" {value}";
            }
            Console.WriteLine(s + " series");
            return s + " series";
        }

        private static string GetTrend(List<string> stockValues, string name) {
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
