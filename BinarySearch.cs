namespace Algorithms
{
    public static class BinarySearch
    {

        public static int Binary_SearchRecursive(string[] AccNumbers, int left, int right, string inputAccNumber)
        {
           if(left <= right) {

                var middle = (left + right) / 2;
                var result = inputAccNumber.CompareTo(AccNumbers[middle]);

                if (result == 0)
                    return middle;

                if (result > 0)
                    return Binary_SearchRecursive(AccNumbers, middle + 1, right, inputAccNumber);//right search

                else
                    return Binary_SearchRecursive(AccNumbers, left, middle - 1, inputAccNumber);//left search



            }
            return -1;
               
        }
    }
}
