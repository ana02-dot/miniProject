namespace Algorithms
{
     public class Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Transaction(DateTime date, double Amount)
        {
            Date = date;
            this.Amount = Amount;
        } 

        public static void TPL(Transaction transaction)
        {
            Console.WriteLine($"Transaction on {transaction.Date.ToShortDateString()} --> {transaction.Amount}$");
        }
    } 
        public class Sortbyalgo
        {
            public static void QuickSort(List<Transaction> transactions, int left, int right)
            {
                int i = left;
                int j = right;

                var pivot = transactions[(left + right) / 2];

                while (i <= j)
                {
                    while (transactions[i].Amount < pivot.Amount)
                        i++;

                    while (transactions[j].Amount > pivot.Amount)
                        j--;
                
                if (i <= j)
                {
                    var tmp = transactions[i];
                    transactions[i] = transactions[j];
                    transactions[j] = tmp;

                    i++;
                    j--;
                }
                }
                if (left < j)
                {
                    QuickSort(transactions, left, j);
                }
                if (i < right)
                {
                    QuickSort(transactions, i, right);
                }
            }

        }
    }


