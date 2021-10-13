using System;
using System.Collections.Generic;
using System.Text;

namespace workout
{
    public class MergeSortedArray
    {
        public static void Solve(String[] args)
        {
            List<List<int>> arrays = new List<List<int>>();
            List<int> subArray;
            foreach (var item in args)
            {
                var inputString = item.Split(' ');
                subArray = new List<int>();
                foreach (var str in inputString)
                {
                    subArray.Add(Convert.ToInt32(str));
                }
                arrays.Add(subArray);
            }
            var result = MergeSort(arrays, 0, arrays.Count - 1);
            foreach (var item in result)
            {
                Console.WriteLine($"{item} ");
            }
        }

        private static List<int> MergeSort(List<List<int>> arrays, int start, int end)
        {
            if (end == start)
            {
                return arrays[start];
            }
            int middle = ((end - start) / 2) + start;
            var leftArray = MergeSort(arrays, start, middle);
            var rightArray = MergeSort(arrays, middle + 1, end);
            return Merge(leftArray, rightArray);
        }

        private static List<int> Merge(List<int> leftArray, List<int> rightArray)
        {
            int left = 0, right = 0, result = 0;
            List<int> resultArray = new List<int>();
            while (left < leftArray.Count || right < rightArray.Count)
            {
                if (left < leftArray.Count && right < rightArray.Count)
                {
                    if (leftArray[left] <= rightArray[right])
                    {
                        resultArray.Add(leftArray[left]);
                        left++;
                        result++;
                    }
                    else
                    {
                        resultArray.Add(rightArray[right]);
                        right++;
                        result++;
                    } 
                }
                else if (left >= leftArray.Count)
                {
                    resultArray.Add(rightArray[right]);
                    right++;
                    result++;
                }
                else if (right >= rightArray.Count)
                {
                    resultArray.Add(leftArray[left]);
                    left++;
                    result++;
                }
            }
            return resultArray;
        }
    }
}
