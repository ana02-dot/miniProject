using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Algorithms
{
     class Prefix_Sum
    {
        public static void PrefixSum(Dictionary<string,double> transactionDict,Dictionary<string, double> prefixSum, int startDay, int endDay)
        {

            double SumOfEachDay = 0;

            foreach (var item in transactionDict)
            {
                SumOfEachDay += item.Value;
                prefixSum[item.Key] = SumOfEachDay;

            }
            string endDayKey = "day " + endDay;
            string startDayKey = "day " + startDay;

            double EndDaySum = prefixSum[endDayKey];
            double StartDaySum = startDay > 1 ? prefixSum["day "+ (startDay - 1)] : 0;


            double result = EndDaySum - StartDaySum;
            Console.WriteLine($"Sum from day {startDay} to day {endDay}: {result}"); 
        }
    }
}
