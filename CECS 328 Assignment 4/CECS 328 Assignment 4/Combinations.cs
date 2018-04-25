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
        static int counter =1; //using this variable to find the ith subset that the user wants to print out 

        public  void combinationUtil(int []arr,int []data, int start,int end,int index,int r)
        {
            if (index == r)
            {
                Console.Write("{ ");
                for(int j = 0; j < r; j++)
                {

                    if (j == r - 1) //if this is the last number in the sub set
                    {
                        Console.Write(data[j] + " "); //print out last number in set with no comma after it 
                        j++;
                    }
                    else
                    {
                        Console.Write(data[j] + ", "); //print out number in subset 
                    }
                    
                }
                Console.Write("}");
                Console.WriteLine("");
                return;
            }
            for (int i = start; i <= end && end - i + 1>= r - index;i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1, end, index+1, r); //recursion 
            }
        }

       public  void printCombination(int []arr,int n,int r)
        {
            int []data=new int[r];
            combinationUtil(arr, data, 0,n-1,0,r); 
        }
        //////

        public void combinationUtil2(int[] arr, int[] data, int start, int end, int index, int r ,int ithSubset)
        { //used specifically for option 3, takes in ith subset number as a paramter
            
            if(index==r && counter == ithSubset)
            {
                Console.WriteLine("ith subset (#"+counter+")");
                Console.Write("{ ");
                for (int j = 0; j < r; j++)
                {

                    if (j == r - 1)
                    {
                        Console.Write(data[j] + " "); //print out last number in set with no comma after it 
                        j++;
                    }
                    else
                    {
                        Console.Write(data[j] + ", ");
                    }

                }
                Console.Write("}");
                Console.WriteLine("");
                counter++; //increment counter to know what subset number we are on 
                return;
            }


          else  if (index == r)
            {
               
                counter++; //increment counter to stay on track with what subset number we are currently on 
                return;
            }
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil2(arr, data, i + 1, end, index + 1, r,ithSubset);
            }
        }

        public void printCombination2(int[] arr, int n, int r,int ithSubset) //used for option 3, takes in ith subset number as a parameter
        {
            int[] data = new int[r];
            combinationUtil2(arr, data, 0, n - 1, 0, r,ithSubset);
        }




    }
}
