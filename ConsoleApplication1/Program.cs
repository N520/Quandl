using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        private static string[] names = { "NASDAQ_MSFT", "NASDAQ_AAPL", "NASDAQ_GOOG" };

        static void Main(string[] args) {
            foreach (var name in names) {
               
            }
        }

        private static string RetrieveStockData(string name) {
            return $"{name} stockValues";
        }

        private static string GetSeries(List<string> stockValues, string name) {
            string s = $"{name}";
            foreach (var value in stockValues) {
                s += $" {value}";
            }
            return s + " series";
        }

        private static string GetTrend(List<string> stockValues, string name) {
            string s = $"{name}";
            foreach (var value in stockValues) {
                s += $" {value}";
            }
            return s + " trend";
        }
    }
}
