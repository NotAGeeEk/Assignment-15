using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public class SortingAlgorithms
    {
        static void Main()
        {
            int[] arr = GenerateRandomArray(20, 1, 100); // Generate a random array of 20 integers between 1 and 100
            Console.WriteLine("Original Array:");
            PrintArray(arr);

            QuickSort(arr, 0, arr.Length - 1); // It sort the array using Quicksort
            Console.WriteLine("\nSorted Array:");
            PrintArray(arr);

            bool isSorted = IsSorted(arr); // Here we check if the array is sorted correctly
            Console.WriteLine("\nIs the array sorted? " + isSorted);

            PerformQuickSortPerformanceAnalysis();

            Console.ReadLine();
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(minValue, maxValue + 1);
            }
            return arr;
        }

        static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void PerformQuickSortPerformanceAnalysis()
        {
            int[] arraySizes = { 20, 30, 50 };

            Console.WriteLine("\nPerformance Analysis of Quicksort\n");

            foreach (int size in arraySizes)
            {
                int[] arr = GenerateRandomArray(size, 1, 1000); // It can generate random array of specified size

                // It can measure the time it takes to sort the array using Quicksort Algo
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                QuickSort(arr, 0, arr.Length - 1);
                stopwatch.Stop();

                Console.WriteLine($"Array Size: {size}, Time Taken: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}