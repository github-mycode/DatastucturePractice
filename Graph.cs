using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class Graph
    {
        public bool[,] AdjMatrix;
        public LinkedList<Vertex>[] AdjList;
        public Vertex[] VertexList;
        public int MaxCount;
        public int VertexCount;

        public Graph(int vertexCount, int maxCount)
        {
            this.VertexCount = vertexCount;
            this.MaxCount = maxCount;

            AdjMatrix = new bool[maxCount, maxCount];
            AdjList = new LinkedList<Vertex>[maxCount];
            for(int i= 0; i<maxCount; i++)
            {
                for (int j = 0; j < maxCount; j++)
                {
                    AdjMatrix[i, j] = false;
                }
            }
            VertexList = new Vertex[maxCount];
        }
    }
}
