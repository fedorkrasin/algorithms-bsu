using System;
using System.Collections.Generic;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphList = new List<int>[]
            {
                new List<int> {3},
                new List<int> { },
                new List<int> {6, 7},
                new List<int> {0, 4, 5},
                new List<int> {3},
                new List<int> {3},
                new List<int> {2, 7},
                new List<int> {2, 6},
            };

            var graph = new Graph(graphList);
            var list = graph.FindComponents();

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}