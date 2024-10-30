using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Detections
    {
        public int ID { get; set; }
        public string AccountInfo { get; set; }
        public double Amount { get; set; }

    }

    public class AnomalyDetection
    {
        public static void DetectAnomalies(List<Detections> anomaly_list)
        {
            double sashualo = anomaly_list.Average(t => t.Amount);
            double sashualo_gadakhra = Math.Sqrt(anomaly_list.Sum(t => Math.Pow(t.Amount - sashualo, 2)) / anomaly_list.Count);

            Console.WriteLine($"Mean: {sashualo}, Standard Deviation: {sashualo_gadakhra}");

            foreach (var items in anomaly_list)
            {

                double zScore = (items.Amount - sashualo) / sashualo_gadakhra;
                if (Math.Abs(zScore) > 1.5)
                {
                    Console.WriteLine($"Anomalous Transaction Detected: ID = {items.ID}, Amount = {items.Amount}, Z-Score = {zScore}");
                }

            }
        }

    }
}
