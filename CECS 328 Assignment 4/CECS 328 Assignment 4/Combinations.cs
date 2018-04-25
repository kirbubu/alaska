using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4

{

    class Combinations
    {
        public List<int> holdStuff = new List<int>();
        public int[] hold;
        public bool nextCombination(int[] array, int k, int maxS)
        {
            hold =  new int[array.Length];
            for(int j = k - 1; j>0; j--)
            {

                if ((array[j] + (k - j)) < maxS)
                {
                    int value = array[j] + 1;
                    for (int r = j; r > k - 1; r--)
                    {
                        array[r] = value;
                        hold[r] = value;
                        value++;
                    }

                    for(int i = 0; i < hold.Length; i++)
                    {
                        Console.WriteLine(hold[i]);
                    }


                  //  holdStuff = array.ToList();
                    return true; 
                }
            }
            return false;
        }
    }
}
