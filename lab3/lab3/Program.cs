using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1();
            Task3();
        }

        private static void Task1()
        {
            Console.WriteLine("Graph 1");
            var graphList = new[]
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
            var components = graph.FindComponents();

            for (var i = 0; i < components.Count; i++)
            {
                Console.Write("Component " + (i + 1) + ": ");
                Console.WriteLine(string.Join(", ", components[i]));
            }

            Console.WriteLine("Is graph euler: " + graph.IsEuler());

            Console.WriteLine("\nGraph 2");
            var eulerGraphList = new[]
            {
                new List<int> {2, 3},
                new List<int> {3, 4},
                new List<int> {0, 4},
                new List<int> {0, 1},
                new List<int> {1, 2}
            };

            var eulerGraph = new Graph(eulerGraphList);

            Console.WriteLine("Is graph euler: " + eulerGraph.IsEuler());
        }

        private static void Task3()
        {
            // var graph = new[,]
            // {
            //     {-1, 2, 4, 4, 4, 6, 6},
            //     {2, -1, 2, 3, 4, 5, 4},
            //     {4, 2, -1, 2, 4, 2, 2},
            //     {4, 3, 2, -1, 1, 2, 4},
            //     {4, 4, 4, 1, -1, 4, 7},
            //     {6, 5, 2, 2, 4, -1, 4},
            //     {6, 4, 2, 4, 7, 4, -1}
            // };

            var graph = new[,]
            {
                {-1, 2, 6, 10, 6, 2, 4, 4, 5, 1},
                {2, -1, 4, 10, 5, 3, 6, 2, 7, 2},
                {6, 4, -1, 7, 1, 4, 8, 2, 5, 9},
                {10, 10, 7, -1, 6, 7, 8, 9, 4, 11},
                {6, 5, 1, 6, -1, 4, 7, 4, 4, 9},
                {2, 3, 4, 7, 4, -1, 5, 5, 5, 5},
                {4, 6, 8, 8, 7, 5, -1, 8, 3, 5},
                {4, 2, 2, 9, 4, 5, 8, -1, 8, 8},
                {5, 7, 5, 4, 4, 5, 3, 8, -1, 8},
                {1, 2, 9, 11, 9, 5, 5, 8, 8, -1}
            };
            
            TSP.TravellingSalesmanProblem(graph);
        }
    }
}