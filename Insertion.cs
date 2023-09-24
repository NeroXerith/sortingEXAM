using System;
using System.Globalization;

public class Insertion
{
    static int[] numArr;

    public void InsertionSort()
    {
        int n = GetMaxArraySize();
        numArr = GetUserInput(n);

        int[][] simulations = new int[n * n][]; 

        int[] sortedArr = SortNumbers(simulations);
        Console.WriteLine("\nUnsorted Data:");
        DisplayNumbersWithCommas(numArr);

        Console.WriteLine("\nSorted Data:");
        DisplayNumbersWithCommas(sortedArr);

        Console.WriteLine("\nSort Simulations:");
        DisplaySortSimulations(simulations);

        Console.Read();
    }

    static int GetMaxArraySize()
    {
        int maxInput = 0;

        while (true)
        {
            try
            {
                Console.Write("Max Input: ");
                maxInput = int.Parse(Console.ReadLine());

                if (maxInput <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    continue;
                }

                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        return maxInput;
    }

    static int[] GetUserInput(int n)
    {
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n|--- Input #{i + 1} ---|");

            while (true)
            {
                try
                {
                    Console.Write("Input Number: ");
                    arr[i] = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        return arr;
    }

    static int[] SortNumbers(int[][] simulations)
    {
        int[] arr = new int[numArr.Length];
        numArr.CopyTo(arr, 0);

        int simulationCounter = 0; // Initialize the simulation counter

        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            // Store the current state of the array in simulations array
            simulations[simulationCounter] = new int[arr.Length];
            arr.CopyTo(simulations[simulationCounter], 0);

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;

                simulationCounter++; // Increment the simulation counter
            }

            arr[j + 1] = key;
        }

        return arr;
    }

    static void DisplayNumbersWithCommas(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i].ToString("N0", CultureInfo.InvariantCulture));

            if (i < arr.Length - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }

    static void DisplaySortSimulations(int[][] simulations)
    {
        int simulationCtr =0;
        for (int i = 0; i < simulations.Length; i++)
        {
            if (simulations[i] != null)
            {
                Console.Write($"Simulation [{simulationCtr}]: ");
                DisplayNumbersWithCommas(simulations[i]);
                simulationCtr++;
            }
        }
        Console.WriteLine($"\nTotal simulations: {simulationCtr}");
    }
}
