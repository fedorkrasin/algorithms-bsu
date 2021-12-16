using System;

namespace lab3
{
    public class ShortestPath
    {
        private const int noWay = 99999;

        public static void FloydWarshall(int[,] graph)
        {
            var graphLength = graph.GetLength(0);
            var dist = new int[graphLength, graphLength];

            for (var i = 0; i < graphLength; i++)
            {
                for (var j = 0; j < graphLength; j++)
                {
                    if (graph[i, j] == noWay && graph[j, i] != noWay)
                    {
                        graph[i, j] = graph[j, i];
                    }
                }
            }

            for (var i = 0; i < graphLength; i++)
            {
                for (var j = 0; j < graphLength; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }


            for (var k = 0; k < graphLength; k++)
            {
                for (var i = 0; i < graphLength; i++)
                {
                    for (var j = 0; j < graphLength; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            var max = new int[graphLength];
            for (var i = 0; i < graphLength; i++)
            {
                max[i] = dist[i, 0];
                for (var j = 0; j < graphLength; j++)
                {
                    if (max[i] < dist[i, j])
                    {
                        max[i] = dist[i, j];
                    }
                }
            }

            var res = new[] {noWay, 0};
            for (var i = 0; i < graphLength; i++)
            {
                if (max[i] < res[0])
                {
                    res[0] = max[i];
                    res[1] = i;
                }
            }

            PrintSolution(dist, res);
        }

        private static void PrintSolution(int[,] dist, int[] minDist)
        {
            var distanceLength = dist.GetLength(0);
            Console.WriteLine("Matrix of shortest distance between pairs of vertices:");
            
            for (var i = 0; i < distanceLength; ++i)
            {
                for (var j = 0; j < distanceLength; ++j)
                {
                    if (dist[i, j] == noWay) Console.Write("INF ");
                    else Console.Write(dist[i, j] + "\t");
                }

                Console.WriteLine();
            }
            
            Console.WriteLine($"Minimum distance is {minDist[0]}. Best crossroad is {minDist[1]}");
        }
    }
}