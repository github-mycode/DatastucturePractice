using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class GraphAdjL
    {
        private int VertexCount;
        private List<int> vertices;
        private LinkedList<int>[] edges;

        public GraphAdjL(int vertexCount)
        {
            this.VertexCount = vertexCount;
            vertices = new List<int>();
            edges = new LinkedList<int>[vertexCount];
            for(int i = 0; i < vertexCount; i++)
            {
                vertices.Add(i);
                edges[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int source, int destination)
        {
            int i = vertices.IndexOf(source);
            int j = vertices.IndexOf(destination);
            if(i != -1 && j != -1)
            {
                edges[i].AddFirst(destination);
                edges[j].AddFirst(source);
            }
        }
    }
}
