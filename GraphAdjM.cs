
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class GraphAdjM
    {
        private bool[,] AdjMatrix;
        private int VertexCount;
        private int MaxVertexCount = 8;
        private Vertex[] VertexList;
        private Stack<int> DFSStack;
        private Queue<int> BFSQueue;
        public GraphAdjM(int vertexCount)
        {
            this.VertexCount = 0;

            DFSStack = new Stack<int>();
            BFSQueue = new Queue<int>();
            AdjMatrix = new bool[MaxVertexCount, MaxVertexCount];
            for(int i = 0; i< MaxVertexCount; i++)
            {
                for(int j=0; j< MaxVertexCount; j++)
                {
                    AdjMatrix[i, j] = false;
                }
            }
            VertexList = new Vertex[MaxVertexCount];

        }

        public List<int> getAdjUnvisitedVertexes(int v)
        {
            List<int> listNode = new List<int>();
            for (int j = 0; j < VertexCount; j++)
            {

            }
            return listNode;
        }
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < VertexCount; j++)
            {
                if (AdjMatrix[v, j] == true && !VertexList[j].visited)
                {
                    return j;
                }
            }
            return -1;
        }
        public void adddVertex(char lab)
        {
            VertexList[VertexCount++] = new Vertex(lab);
        }

        public void diplayVertex(int v)
        {
            Console.WriteLine(VertexList[v].Label);
        }
        public void AddEdge(int i, int j)
        {
            this.AdjMatrix[i,j] = true;
            this.AdjMatrix[j,i] = true;
        }
        public void RemoveEdge(int i, int j)
        {
            this.AdjMatrix[i, j] = false;
            this.AdjMatrix[j, i] = false;
        }
        public bool IsEdge(int i, int j)
        {
            return AdjMatrix[i, j];
        }
        public void dfs()
        {
            VertexList[0].visited = true;
            DFSStack.Push(0);
            diplayVertex(0);
            while (DFSStack.Count > 0)
            {
                int v = DFSStack.Peek();
                //get an unvisited vertex
                int unvistedNode = getAdjUnvisitedVertex(v);
                //if deadend then pop the element
                if(unvistedNode == -1)
                {
                    DFSStack.Pop();
                }
                else
                {
                    
                    DFSStack.Push(unvistedNode);
                    diplayVertex(unvistedNode);
                }
            }
            //reset the flag
            for(int i=0; i<VertexCount; i++)
            {
                VertexList[i].visited = false;
            }
        }
        public void bfs()
        {
            VertexList[0].visited = true;
            BFSQueue.Enqueue(0);
            diplayVertex(0);
            while (BFSQueue.Count > 0)
            {
                int v = BFSQueue.Dequeue();
                List<int> unvistedNode = getAdjUnvisitedVertexes(v);
                foreach (int node in unvistedNode)
                {
                    VertexList[node].visited = true;
                    BFSQueue.Enqueue(node);
                    diplayVertex(node);
                }
            }

            //reset the flag
            for (int i = 0; i < VertexCount; i++)
            {
                VertexList[i].visited = false;
            }
        }
    }
}
