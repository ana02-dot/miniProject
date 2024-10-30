using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class KMeans
    {
        public static List<int> Cluster(string[] AccNumbers, double[][] data, int k, int maxIteration = 1000)
        {
            var random = new Random();
            var clusters = new List<double[]>(k);
            for (int i = 0; i < k; i++)
            {
                clusters.Add(data[random.Next(data.Length)]);

            }
            var labels = new int[data.Length];
           

            for (int iteration = 0; iteration < maxIteration; iteration++)
            {
                for (int i = 0; i < data.Length; i++)
                    labels[i] = NearestCluster(data[i], clusters);

                var newClusters = new List<double[]>(k);
                for (int i = 0; i < k; i++)
                    newClusters.Add(new double[data[0].Length]);

                var counts = new int[k];
                for (int i = 0; i < data.Length; i++)
                {
                    var cluster = labels[i];
                    for (int j = 0; j < data[i].Length; j++)
                        newClusters[cluster][j] += data[i][j];
                    counts[cluster]++;
                }

                for (int i = 0; i < k; i++)
                    for (int j = 0; j < newClusters[i].Length; j++)
                        newClusters[i][j] /= counts[i];

                if (!clusters.Where((t, i) => t.SequenceEqual(newClusters[i])).Any())
                    break;

                clusters = newClusters;
            }

            return labels.ToList();
        }

        private static int NearestCluster(double[] point, List<double[]> clusters)
        {
            var nearest = 0;
            var minDistance = double.MaxValue;
            for (int i = 0; i < clusters.Count; i++)
            {
                var distance = EuclideanDistance(point, clusters[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = i;
                }
            }
            return nearest;
        }

        private static double EuclideanDistance(double[] a, double[] b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
                sum += Math.Pow(a[i] - b[i], 2);
            return Math.Sqrt(sum);

        }
    }
}
