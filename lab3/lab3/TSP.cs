using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    public class TSP
    {
        public static void TravellingSalesmanProblem(int[,] graph)
        {
            var lists = Permute(Enumerable.Range(0, graph.GetLength(0)).ToArray());
            var permutesNumber = lists.Count;
            var weights = new int[permutesNumber];
            var index = 0;
            var minWeight = int.MaxValue;
            var minWeightIndex = 0;

            foreach (var list in lists)
            {
                var weight = 0;

                for (var i = 0; i < list.Count - 1; i++)
                {
                    weight += graph[list[i], list[i + 1]];
                }

                weights[index] = weight;
                if (weight < minWeight)
                {
                    minWeight = weight;
                    minWeightIndex = index;
                }
                
                index++;
            }

            Console.WriteLine("Shortest route is " + string.Join("-", lists[minWeightIndex].ToArray()) +
                              $", weight is {minWeight}");
        }
        
        public static IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            return DoPermute(nums, 0, nums.Length - 1, list);
        }

        private static IList<IList<int>> DoPermute(int[] nums, int start, int end, IList<IList<int>> list)
        {
            if (start == end)
            {
                list.Add(new List<int>(nums));
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    Swap(ref nums[start], ref nums[i]);
                    DoPermute(nums, start + 1, end, list);
                    Swap(ref nums[start], ref nums[i]);
                }
            }

            return list;
        }

        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        
        public static void PrintResult(IList<IList<int>> lists)
        {
            Console.WriteLine("[");
            foreach (var list in lists) Console.WriteLine($"    [{string.Join(',', list)}]");
            Console.WriteLine("]");
        }
    }
}