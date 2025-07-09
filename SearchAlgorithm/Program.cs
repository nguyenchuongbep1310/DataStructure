using System;

namespace SearchAlgorithms
{
    class Program
    {
        private static Random random = new Random();
        
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            
            Console.WriteLine("=== METHOD 1: Generate random then sort ===");
            FillArrayRandomSort(array1);
            Console.WriteLine("Sorted array:");
            PrintArray(array1);
            Console.WriteLine("\n");
            
            Console.WriteLine("=== METHOD 2: Generate incrementally ===");
            FillArrayIncremental(array2);
            Console.WriteLine("Incremental array:");
            PrintArray(array2);
            Console.WriteLine("\n");
            
            // Test search algorithms
            Console.Write("Enter a number to search: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                int result1 = LinearSearch(array1, target);
                int result2 = BinarySearch(array1, target);
                int result3 = BinarySearchRecursive(array1, target, 0, array1.Length - 1);
                
                PrintSearchResult("Linear Search", result1, target);
                PrintSearchResult("Binary Search (Iterative)", result2, target);
                PrintSearchResult("Binary Search (Recursive)", result3, target);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // Method 1: Generate random numbers then sort
        static void FillArrayRandomSort(int[] arr)
        {
            // Generate random numbers
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 100); // 0-99
            }
            
            // Sort in ascending order
            Array.Sort(arr);
        }
        
        // Method 2: Generate incrementally sorted array
        static void FillArrayIncremental(int[] arr)
        {
            arr[0] = random.Next(0, 10); // First element 0-9
            
            for (int i = 1; i < arr.Length; i++)
            {
                // Each next element = previous + (1 to 10)
                arr[i] = arr[i - 1] + random.Next(1, 11);
            }
        }
        
        static void PrintArray(int[] arr)
        {
            foreach (int value in arr)
            {
                Console.Write($"{value}\t");
            }
            Console.WriteLine();
        }
        
        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        
        static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Avoid overflow
                
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            
            return -1;
        }
        
        static int BinarySearchRecursive(int[] arr, int target, int left, int right)
        {
            if (left > right)
                return -1;
            
            int mid = left + (right - left) / 2; // Avoid overflow
            
            if (arr[mid] == target)
                return mid;
            
            if (arr[mid] > target)
                return BinarySearchRecursive(arr, target, left, mid - 1);
            else
                return BinarySearchRecursive(arr, target, mid + 1, right);
        }
        
        static void PrintSearchResult(string method, int result, int target)
        {
            Console.Write($"{method}: ");
            if (result == -1)
                Console.WriteLine($"Could not find {target} in the array");
            else
                Console.WriteLine($"Found {target} at position {result}");
        }
    }
}