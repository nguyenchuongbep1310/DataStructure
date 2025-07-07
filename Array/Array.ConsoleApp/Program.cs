using System;
using System.Collections.Generic;

class ArrayUtils
{
    // 1. Get alternate elements of an array
    static List<int> GetAlternateElements(int[] arr)
    {
        var result = new List<int>();
        for (int i = 0; i < arr.Length; i += 2)
        {
            result.Add(arr[i]);
        }
        return result;
    }

    // 2. Linear Search
    public static int LinearSearch(int[] arr, int value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == value) return i;
        }
        return -1;
    }

    // 3. Find largest element
    static int FindMax(List<int> arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    // 4. Find second largest distinct element
    public static int GetSecondLargest(int[] arr)
    {
        Array.Sort(arr);
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i] != arr[^1])
                return arr[i];
        }
        return -1;
    }

    // 5. Get top 3 largest distinct elements
    public static List<int> GetTop3Largest(int[] arr)
    {
        int? first = null, second = null, third = null;

        foreach (var x in arr)
        {
            if (x == first || x == second || x == third)
                continue;

            if (first == null || x > first)
            {
                third = second;
                second = first;
                first = x;
            }
            else if (second == null || x > second)
            {
                third = second;
                second = x;
            }
            else if (third == null || x > third)
            {
                third = x;
            }
        }

        var result = new List<int>();
        if (first != null) result.Add(first.Value);
        if (second != null) result.Add(second.Value);
        if (third != null) result.Add(third.Value);
        return result;
    }

    // 6. Find leaders in array
    static List<int> FindLeaders(int[] arr)
    {
        var result = new List<int>();
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            bool isLeader = true;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] > arr[i])
                {
                    isLeader = false;
                    break;
                }
            }
            if (isLeader)
                result.Add(arr[i]);
        }

        return result;
    }

    // 7. Check if array is sorted (non-decreasing)
    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] > arr[i])
                return false;
        }
        return true;
    }

    // 8. Remove duplicates from sorted array
    static int RemoveDuplicates(int[] arr)
    {
        if (arr.Length <= 1) return arr.Length;

        int idx = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
                arr[idx++] = arr[i];
        }
        return idx;
    }

    static void Main()
    {
        // 1. Alternate Elements
        var arr1 = new[] { 10, 20, 30, 40, 50 };
        Console.WriteLine("Alternate elements: " + string.Join(" ", GetAlternateElements(arr1)));

        // 2. Linear Search
        var arr2 = new[] { 2, 3, 4, 10, 40 };
        int valueToFind = 10;
        int index = LinearSearch(arr2, valueToFind);
        Console.WriteLine(index == -1
            ? "Element is not present in array"
            : $"Element is present at index {index}");

        // 3. Largest Element
        var list3 = new List<int> { 10, 324, 45, 90, 9808 };
        Console.WriteLine($"Max value: {FindMax(list3)}");

        // 4. Second Largest
        var arr4 = new[] { 12, 35, 1, 10, 1 };
        Console.WriteLine($"Second largest: {GetSecondLargest(arr4)}");

        // 5. Top 3 Largest
        var arr5 = new[] { 12, 13, 1, 10, 34, 1 };
        Console.WriteLine("Top 3 largest: " + string.Join(" ", GetTop3Largest(arr5)));

        // 6. Leaders in array
        var arr6 = new[] { 16, 17, 4, 3, 5, 2 };
        Console.WriteLine("Leaders: " + string.Join(" ", FindLeaders(arr6)));

        // 7. Is Sorted
        var arr7 = new[] { 20, 23, 23, 45, 78, 88 };
        Console.WriteLine(IsSorted(arr7) ? "Yes" : "No");

        // 8. Remove Duplicates
        var arr8 = new[] { 1, 2, 2, 3, 4, 4, 4, 5, 5 };
        int newLength = RemoveDuplicates(arr8);
        Console.WriteLine("After removing duplicates: " + string.Join(" ", arr8[..newLength]));
    }
}