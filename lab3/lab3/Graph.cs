using System.Collections.Generic;

namespace lab3
{
    public class Graph
    {
        private int[] _vertices;
        private List<int>[] _adjacencyLists;

        public Graph(int[] vertices, List<int>[] adjacencyLists)
        {
            _vertices = vertices;
            _adjacencyLists = adjacencyLists;
        }
    }
}