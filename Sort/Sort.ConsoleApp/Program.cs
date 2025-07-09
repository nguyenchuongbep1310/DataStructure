using System;

namespace ArrayUtilities
{
    class Program
    {
        private static readonly Random random = new();
        private static int[] array = new int[10];

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Generate Random Array (Sorted)");
                Console.WriteLine("2. Generate Incremental Array");
                Console.WriteLine("3. Print Array");
                Console.WriteLine("4. Sort with Bubble Sort");
                Console.WriteLine("5. Sort with Selection Sort");
                Console.WriteLine("6. Sort with Insertion Sort");
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
                        BubbleSort(array);
                        Console.WriteLine("Sorted with Bubble Sort.");
                        break;

                    case "5":
                        SelectionSort(array);
                        Console.WriteLine("Sorted with Selection Sort.");
                        break;

                    case "6":
                        InsertionSort(array);
                        Console.WriteLine("Sorted with Insertion Sort.");
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

        // ===== Array Generation =====

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

        // ===== Sorting Algorithms =====

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                }
            }
        }

        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min]) min = j;

                if (min != i)
                    (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }

        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int x = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > x)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = x;
            }
        }
    }
}
