﻿using System.Collections.Generic;

namespace lab3
{
    public class Graph
    {
        private List<int>[] _adjacencyLists;

        public Graph(List<int>[] adjacencyLists)
        {
            _adjacencyLists = adjacencyLists;
        }
        
        public List<List<int>> FindComponents()
        {
            var components = new List<List<int>>();
            var componentIndex = 0;
            var dfsUsed = new bool[_adjacencyLists.Length];

            for (var i = 0; i < _adjacencyLists.Length; i++)
            {
                if (!dfsUsed[i])
                {
                    components.Add(new List<int>());
                    DepthFirstSearch(i);
                    componentIndex++;
                }
            }

            void DepthFirstSearch(int vertex)
            {
                dfsUsed[vertex] = true;
                components[componentIndex].Add(vertex);
                for (var i = 0; i < _adjacencyLists[vertex].Count; i++)
                {
                    var to = _adjacencyLists[vertex][i];
                    if (!dfsUsed[to])
                    {
                        DepthFirstSearch(to);
                    }
                }
            }

            return components;
        }
    }
}