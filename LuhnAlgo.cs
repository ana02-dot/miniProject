using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Algorithms
{
    class LuhnAlgo
    {
        public static bool CheckByLuhn(string OnlyDigits)
        {

            int nDigits = OnlyDigits.Length;
            bool isSecond = false;
            int nSum = 0;
            
            for(int i = nDigits-1; i >= 0; i--)
            {
                int digit = OnlyDigits[i] - '0';

                if (isSecond == true)
                    digit *= 2;

               /* nSum = nSum + digit / 10; //tens place
                nSum = nSum + digit % 10; //ones place*/


                if(digit > 9)
                {
                    digit -= 9;
                }
                nSum += digit;

                isSecond = !isSecond;


            }return nSum % 10 == 0;
        }
    }
}


