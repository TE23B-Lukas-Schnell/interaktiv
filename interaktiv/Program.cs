using System;
using System.Collections.Generic;

namespace BogoSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a list of integers
            Console.WriteLine("Enter a list of integers separated by spaces:");
            string input = Console.ReadLine();

            // Split the input into an array of strings and convert them to integers
            List<int> list = new List<int>();
            foreach (string s in input.Split(' '))
            {
                if (int.TryParse(s, out int num))
                {
                    list.Add(num);
                }
                else
                {
                    Console.WriteLine($"'{s}' is not a valid integer. Please enter valid integers.");
                    return;
                }
            }

            Console.WriteLine("Sorting...");


            // Calling the Bogo_sort function with optional parameters (announce and delay)
            Bogo_sort(list, true, 100);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Function to perform Bogo sort
        static void Bogo_sort(List<int> list, bool announce, int delay)
        {
            int iteration = 0;
            // Loop until the list is sorted
            while (!IsSorted(list))
            {
                if (announce)
                {
                    // Print the current iteration if announce is set to true
                    Print_Iteration(list, iteration);
                }
                if (delay != 0)
                {
                    // Introduce a delay if delay parameter is non-zero
                    System.Threading.Thread.Sleep(Math.Abs(delay));
                }
                // Rearrange the list elements randomly
                list = Remap(list);
                iteration++; // Increment iteration count
            }

            Print_Iteration(list, iteration); // Print the final sorted list
            Console.WriteLine();
            Console.WriteLine("Bogo_sort completed after {0} iterations.", iteration); // Display the total iterations
        }

        // Function to print the current iteration of the list
        static void Print_Iteration(List<int> list, int iteration)
        {
            Console.Write("Bogo_sort iteration {0}: ", iteration);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                if (i < list.Count - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

        // Function to check if the list is sorted
        static bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false; // Returns false if the list is not sorted
                }
            }

            return true; // Returns true if the list is sorted
        }

        // Function to rearrange the list elements randomly
        static List<int> Remap(List<int> list)
        {
            int temp;
            List<int> newList = new List<int>();
            Random r = new Random();

            // Randomly rearrange elements from the input list to a new list
            while (list.Count > 0)
            {
                temp = r.Next(list.Count);
                newList.Add(list[temp]);
                list.RemoveAt(temp);
            }
            return newList; // Return the new list with rearranged elements
        }
    }
}
