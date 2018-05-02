using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4

{

    class Combinations
    {
       public static String holdIt="";
        Form1 f = new Form1();
        public List<int> holdStuff = new List<int>();
        public int[] hold;
        // static int counter =1; //using this variable to find the ith subset that the user wants to print out 
       static  int counter = 1;



        //arr is the entire array 
        //data array used to save current combination 
        //start and end are the starting and ending vertices in the arr[]
        //index is the current index in our temporary data array 
        //k is the combination size that they want to print 
        //
        public  void combinationUtil(int []arr,int []data, int start,int end,int index,int k)
        {
            if (index == k) //if the index is the same as r, then we know that the array is full and ready to be printed 
            {
                Console.Write("{ ");
                
                for(int j = 0; j < k; j++)
                {

                    if (j == k - 1) //if this is the last number in the sub set
                    {
                       
                        Console.Write(data[j] + " "); //print out last number in set with no comma after it 
                      //  holdIt+=data[j]+" ";
                        //j++;

                    }
                    else
                    {
                        //holdIt += data[j]+ ", ";
                        Console.Write(data[j] + ", "); //print out number in subset 
                    }
                    
                }
              //  holdIt += "}";
                Console.Write("}");
                Console.WriteLine("");

                return;
            }

            //replace the index with all possible elements. The condition of end-i+1>= k -index makes sure that including one element at index will
            //make a combination with the remaining elements at the remaining positions 
            for (int i = start; i <= end && end - i + 1>= k - index;i++)
            {
                data[index] = arr[i]; //set that index number in temp data array to index i of our entire original array 
                combinationUtil(arr, data, i + 1, end, index+1, k); //recursion 
            }
        }

       public  void printCombination(int []arr,int n,int r)
        {
            //making a temporary array to store the combination one at a time 
            int []data=new int[r];
            combinationUtil(arr, data, 0,n-1,0,r);  //using the temp array of size n to print out the temp array 
        }
        //////

        public static void combinationUtil2(int[] arr, int[] data, int start, int end, int index, int r ,int ithSubset)
        { //used specifically for option 3, takes in ith subset number as a paramter

           // holdIt = "";
            if(index==r && counter == ithSubset)
            {

                Console.WriteLine("ith subset (#"+counter+")");

                holdIt = "{";
                Console.Write("{ ");
                for (int j = 0; j < r; j++)
                {

                    if (j == r - 1)
                    {
                        holdIt += data[j] + " ";
                        Console.Write(data[j] + " "); //print out last number in set with no comma after it 
                     //   j++;
                    }
                    else
                    {
                        holdIt += data[j] + " ,";
                        Console.Write(data[j] + ", ");
                    }

                }
                holdIt += "}";
            //    Console.WriteLine("hold it contents" + holdIt); 
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

        public static void printCombination2(int[] arr, int n, int r,int ithSubset) //used for option 3, takes in ith subset number as a parameter
        {
            int[] data = new int[r];
            combinationUtil2(arr, data, 0, n - 1, 0, r,ithSubset);
        }




    }
}
