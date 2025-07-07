using System;

namespace SearchAlgorithms
{
    class Program
    {
        private static readonly Random random = new();
        private static int[] array = new int[10];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Generate random array and sort");
                Console.WriteLine("2. Generate incremental array");
                Console.WriteLine("3. Print current array");
                Console.WriteLine("4. Linear Search");
                Console.WriteLine("5. Binary Search (Iterative)");
                Console.WriteLine("6. Binary Search (Recursive)");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        FillArrayRandomSort(array);
                        Console.WriteLine("Generated and sorted array.");
                        break;
                    case "2":
                        FillArrayIncremental(array);
                        Console.WriteLine("Generated incremental array.");
                        break;
                    case "3":
                        PrintArray(array);
                        break;
                    case "4":
                        SearchAndPrint(LinearSearch, "Linear Search");
                        break;
                    case "5":
                        SearchAndPrint(BinarySearch, "Binary Search (Iterative)");
                        break;
                    case "6":
                        SearchAndPrint((arr, target) => BinarySearchRecursive(arr, target, 0, arr.Length - 1), "Binary Search (Recursive)");
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void FillArrayRandomSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(0, 100);
            Array.Sort(arr);
        }

        static void FillArrayIncremental(int[] arr)
        {
            arr[0] = random.Next(0, 10);
            for (int i = 1; i < arr.Length; i++)
                arr[i] = arr[i - 1] + random.Next(1, 11);
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine("Array contents:");
            foreach (var val in arr)
                Console.Write($"{val}\t");
            Console.WriteLine();
        }

        static void SearchAndPrint(Func<int[], int, int> searchMethod, string methodName)
        {
            Console.Write("Enter number to search: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                int index = searchMethod(array, target);
                PrintSearchResult(methodName, index, target);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target)
                    return i;
            return -1;
        }

        static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target) return mid;
                if (arr[mid] > target) right = mid - 1;
                else left = mid + 1;
            }
            return -1;
        }

        static int BinarySearchRecursive(int[] arr, int target, int left, int right)
        {
            if (left > right) return -1;
            int mid = left + (right - left) / 2;
            if (arr[mid] == target) return mid;
            return arr[mid] > target
                ? BinarySearchRecursive(arr, target, left, mid - 1)
                : BinarySearchRecursive(arr, target, mid + 1, right);
        }

        static void PrintSearchResult(string method, int result, int target)
        {
            Console.WriteLine($"{method}: " +
                (result == -1 ? $"Could not find {target}" : $"Found {target} at index {result}"));
        }
    }
}
