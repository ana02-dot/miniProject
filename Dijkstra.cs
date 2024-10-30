using ScottPlot.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;


namespace Algorithms
{
    public class Dijkstra
    {
        public static (List<string> Path, int Time) FindShortestPath(
        Dictionary<string, List<Edge>> Fullgraph, string start, string destination)
        {
            var distances = new Dictionary<string, int> { [start] = 0 };
            var previous = new Dictionary<string, string>();
            var queue = new SortedSet<(int Time, string Account)>(
                Comparer<(int, string)>.Create((a, b) =>
                {
                    int timeComparison = a.Item1.CompareTo(b.Item1);
                    return timeComparison != 0 ? timeComparison : string.Compare(a.Item2, b.Item2);
                })
              );

            queue.Add((0, start));

            while (queue.Count > 0)
            {
                var (currentTime, currentAccount) = queue.Min;
                queue.Remove(queue.Min);

                if (currentAccount == destination)
                    return (ReconstructPath(previous, start, destination), currentTime);

                foreach (var edge in Fullgraph.GetValueOrDefault(currentAccount, new List<Edge>()))
                {
                    int newTime = currentTime + edge.Time;

                    if (newTime < distances.GetValueOrDefault(edge.Target, int.MaxValue))
                    {
                        distances[edge.Target] = newTime;
                        previous[edge.Target] = currentAccount;
                        queue.Add((newTime, edge.Target));
                    }
                }
            }

            return (null, 0); // No path found
        }

        private static List<string> ReconstructPath(
            Dictionary<string, string> previous, string start, string destination)
        {
            var path = new List<string>();
            for (var at = destination; at != null; at = previous.GetValueOrDefault(at))
                path.Insert(0, at);
            return path;
        }
    }

    public record Edge(string Target, int Time);
}
