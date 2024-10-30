using Algorithms;
using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScottPlot;
using System.Linq;
using System.Diagnostics;
using System.Threading.Channels;
using System.Globalization;

static class Program
{
    static string pattern = @"^(?i)GE\d{2}[A-Z]{2}0{7}\d{9}$";


    static void Main(string[] args)
    {
        //regex pattern
        /*Regex inputAccNumber = new Regex(pattern);


        if (inputAccNumber.IsMatch("ge60BG0000000366050958"))
        {
            Console.WriteLine("String matches the pattern");
        }
        else
        {
            Console.WriteLine("String doesn't match the pattern");
        }*/



        //quicksort
        List<Transaction> transactions = new List<Transaction>
        {
            new Transaction(new DateTime(2024, 1, 25), 100),
            new Transaction(new DateTime(2024, 1, 25), 10),
            new Transaction(new DateTime(2024, 1, 25), 50),
            new Transaction(new DateTime(2024, 4, 12), 250),
            new Transaction(new DateTime(2024, 5, 19), 168),
            new Transaction(new DateTime(2024, 6, 20), 250),
            new Transaction(new DateTime(2024, 9, 18), 30),
            new Transaction(new DateTime(2024, 9, 18), 250),
            new Transaction(new DateTime(2024, 9, 18), 1500),
            new Transaction(new DateTime(2024, 10, 3), 250),
            new Transaction(new DateTime(2024, 11, 19), 400),
            new Transaction(new DateTime(2024, 12, 4), 550),

        };

        /*double[] amounts = transactions.Select(x => x.Amount).ToArray();
        double[] positions = Enumerable.Range(0, transactions.Count).Select(x => (double)x).ToArray();
        string[] labels = transactions.Select(t => t.Date.ToString("MMM dd")).ToArray();

       
        var plt = new ScottPlot.Plot(800, 600);

        plt.AddBar(values: amounts, positions: positions);

        // Customize the plot
        plt.XTicks(positions, labels);

        plt.XAxis.Label("Date (2024)");
        plt.YAxis.Label("Amount ($)");
        plt.Title("Transaction Amounts Over Time");
       
        string filePath = "transactions.jpg";
        plt.SaveFig(filePath);

        Console.WriteLine($"Plot saved to {filePath}");*/

        //tpl
        //Parallel.ForEach(transactions, (transaction) => { Transaction.TPL(transaction); });


        //json serialization
        /*string jsonString = JsonSerializer.Serialize(transactions);
        Console.WriteLine(jsonString);

*/
        //map key-value
        /*var mappedData = transactions.Select(t => new { t.Date, t.Amount });

        //reduce group by key, sum
        var SumOfDaylyAmount = transactions.GroupBy((date) => date.Date).Select(x => new
        {
            Date = x.Key,
            SumAmount = x.Sum(s => s.Amount)
        });
        foreach (var item in SumOfDaylyAmount)
        {
            Console.WriteLine($"Date: {item.Date}, Total Amount: {item.SumAmount}");
        }
*/
        /*
                Sortbyalgo.QuickSort(transactions, 0, transactions.Count - 1);

                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction.Amount);
                }*/

        //binary search
        string[] AccNumbers = new string[] { "ge344545543534553535453", "ge34343432434243242566", "ge60BG0000000366050958", "ge15BG0000000256357894" };
        /* Array.Sort(AccNumbers);
         foreach (var acc in AccNumbers)
         {
             Console.WriteLine(acc);
         }
        */
        //kmeans
        double[][] data = new double[][]
        {
            new double[]{3000,129.5, 6000},
            new double[]{155,200, 2000},
            new double[]{800,500, 1500},
            new double[]{200,155, 3000},

        };

        var labels = KMeans.Cluster(AccNumbers, data, 6);
        for (int i = 0; i < AccNumbers.Length; i++)
            Console.WriteLine($"{AccNumbers[i]} is in cluster {labels[i]}");


        /*
                int result = BinarySearch.Binary_SearchRecursive(AccNumbers, 0, AccNumbers.Length - 1, "ge60BG0000000366050958");
                if (result == -1)
                    Console.WriteLine("element not found");
                else
                    Console.WriteLine("element found at index " + result);
        */

        /* //luhn algo
         Console.Write("enter your account number -> ");
         string inputAccNumb = Console.ReadLine();

         string OnlyDigits = new string(inputAccNumb.Where(Char.IsDigit).ToArray());

         if (LuhnAlgo.CheckByLuhn(OnlyDigits) && inputAccNumb.Length == 22)
             Console.WriteLine("This is a valid card");
         else
             Console.WriteLine("This is not a valid card");*/

        /*//Prefix sum
        Dictionary<string, double> transactionDict = new Dictionary<string, double>()
        {
            { "day 1", 500.6 },
            { "day 2", 4322 },
            { "day 3", 255.6 },
            { "day 4", 955.4 },
            { "day 5", 699.5 }
        };
        Dictionary<string, double> prefixSumDict = new Dictionary<string, double>();
        Prefix_Sum.PrefixSum(transactionDict, prefixSumDict, 2, 5);*/

        /*//hashset
        HashSet<double> output_Balance = new HashSet<double>();

        foreach (var t in transactions)
        {
            output_Balance.Add(t.Amount);
        }*/
        /*//display output balance
        Console.WriteLine("Unique Transaction Amounts:");
        foreach (var amount in output_Balance)
        {
            Console.WriteLine(amount);
        }*/


        //dijkstra
        var Fullgraph = new Dictionary<string, List<Edge>>()
        {
            { "FirstAcc", new List<Edge> { new("SecondAcc", 5), new("ThirdAcc", 12) } },
            { "SecondAcc", new List<Edge> { new("FourthAcc", 3), new("FifthAcc", 7) } },
            { "ThirdAcc", new List<Edge> { new("FourthAcc", 2) } },
            { "FourthAcc", new List<Edge> { new("FifthAcc", 1) } },
            { "FifthAcc", new List<Edge>() }
        };


        var (path, time) = Dijkstra.FindShortestPath(Fullgraph, "FirstAcc", "SecondAcc");

        Console.WriteLine($"{string.Join(" -> ", path)}");
        Console.WriteLine($"Total Time: {time} minutes");



        //anomalydetection
        var anomaly_list = new List<Detections>
        {
            new Detections { ID = 1, AccountInfo = "ge344545543534553505263", Amount = 100},
            new Detections { ID = 2, AccountInfo = "ge344545543534553789211", Amount = 150 },
            new Detections { ID = 3, AccountInfo = "ge344545543534553535459", Amount = 200},
            new Detections { ID = 4, AccountInfo = "ge344545543534595925453", Amount = 250},
            new Detections { ID = 5, AccountInfo = "ge344545543535959595656", Amount = 1000}
        };

        //AnomalyDetection.DetectAnomalies(anomaly_list);


        //linear forecast

        var monthlyTotals = transactions
            .GroupBy(t => new DateTime(t.Date.Year, t.Date.Month, 1))
            .Select(g => new { Date = g.Key, Total = g.Sum(t => t.Amount) })
            .OrderBy(g => g.Date)
            .ToList();

        // 2. Prepare data for linear regression
        var x = Enumerable.Range(1, monthlyTotals.Count).Select(i => (double)i).ToArray(); // Time periods
        var y = monthlyTotals.Select(mt => mt.Total).ToArray(); // Monthly totals

        // 3. Perform linear regression
        var (slope, intercept) = LinearReg.LinearRegression(x, y);

        
        Console.WriteLine("Forecast for the next 3 months:");
        for (int i = 1; i <= 6; i++)
        {
            double forecastedValue = slope * (x.Length + i) + intercept;
            DateTime forecastDate = monthlyTotals.Last().Date.AddMonths(i);
            Console.WriteLine($"{forecastDate:yyyy-MM}: {forecastedValue:F2}");
        }

    }
}