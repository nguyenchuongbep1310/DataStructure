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
                        Console.WriteLine("Array sorted using Bubble Sort.");
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

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }
            }
        }
    }
}
