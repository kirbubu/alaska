using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS_328_Assignment_4

{

    class Combinations
    {
        public List<int> holdStuff = new List<int>();
        public int[] hold;
        public static int counter =1; //using this variable to find the ith subset that the user wants to print out 
        public static string holdIt;
        public static StringBuilder combinationUtil(int []arr,int []data, int start,int end,int index,int r)
        {
            StringBuilder returnString = new StringBuilder();
            if (index == r)
            {
                returnString.Append("\r\n{ ");
                for(int j = 0; j < r; j++)
                {

                    if (j == r - 1) //if this is the last number in the sub set
                    {
                        returnString.Append(data[j] + " "); //print out last number in set with no comma after it 
                        j++;
                    }
                    else
                    {
                        returnString.Append(data[j] + ", "); //print out number in subset 
                    }
                    
                }
                returnString.Append("}");
                returnString.Append("");
                return returnString;
            }
            for (int i = start; i <= end && end - i + 1>= r - index;i++)
            {
                data[index] = arr[i];
                returnString.Append(combinationUtil(arr, data, i + 1, end, index+1, r)); //recursion 
            }
            return returnString;
        }

       public static StringBuilder printCombination(int n,int r)
        {
            int []data=new int[r];
            int[] arr = new int[n];
            for (int i = 0; i < arr.Count(); i++)
                arr[i] = i + 1;
            return combinationUtil(arr, data, 0,n-1,0,r); 
        }
        //////

       public static List<List<Edge<int>>> vertexCombinations(List<Edge<int>> array, List<Edge<int>> data, int start, int end, int index, int r)
        {
            //Debugger.Break();
            List<List<Edge<int>>> list = new List<List<Edge<int>>>();
            if (index == r)
            {
                List<Edge<int>> vertices = new List<Edge<int>>();
                //returnString.Append("\r\n{ ");
                for (int j = 0; j < r; j++)
                {
                    
             
                        vertices.Add(data[j]);

                }
                //returnString.Append("}");
                //returnString.Append("");
                list.Add(vertices);
                return list;
            }
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = array[i];
                list.AddRange(vertexCombinations(array, data, i + 1, end, index + 1, r)); //recursion 
            }
            return list;
        }
        


       public static List<List<Edge<int>>> ReturnCombinations(List<Edge<int>> array,int r)
        {
            List<Edge<int>> data = new List<Edge<int>>(r);
            for (int i = 0; i < r; i++)
                data.Add(null);
            return vertexCombinations(array, data, 0, array.Count- 1, 0, r);
        }
        public static void combinationUtil2(int[] arr, int[] data, int start, int end, int index, int r, int ithSubset)
        { //used specifically for option 3, takes in ith subset number as a paramter
            
            // holdIt = "";
            if (index == r && counter == ithSubset)
            {

                Console.WriteLine("ith subset (#" + counter + ")");

                holdIt = "{ ";
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


            else if (index == r)
            {

                counter++; //increment counter to stay on track with what subset number we are currently on 
                return;
            }
            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];

                combinationUtil2(arr, data, i + 1, end, index + 1, r, ithSubset);
            }
            //counter = 1;
        }

        public static void printCombination2(int[] arr, int n, int r,int ithSubset) //used for option 3, takes in ith subset number as a parameter
        {
            int[] data = new int[r];
            combinationUtil2(arr, data, 0, n - 1, 0, r,ithSubset);
        }




    }
}
