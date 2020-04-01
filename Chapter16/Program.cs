using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter16
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试拓扑排序，结果显示不正确？？？
            //Graph theGraph = new Graph(6);
            //theGraph.AddVertex("CS1");
            //theGraph.AddVertex("CS2");
            //theGraph.AddVertex("数据结构");
            //theGraph.AddVertex("操作系统");
            //theGraph.AddVertex("算法");
            //theGraph.AddVertex("汇编语言");
            //theGraph.AddEdge(0, 1);
            //theGraph.AddEdge(1, 2);
            //theGraph.AddEdge(1, 5);
            //theGraph.AddEdge(2, 3);
            //theGraph.AddEdge(2, 4);
            //theGraph.TopSort();
            //Console.WriteLine();
            //Console.WriteLine($"Finished.");
            #endregion

            #region 深度优先搜索
            Graph aGraph = new Graph(13);
            aGraph.AddVertex("A");
            aGraph.AddVertex("B");
            aGraph.AddVertex("C");
            aGraph.AddVertex("D");
            aGraph.AddVertex("E");
            aGraph.AddVertex("F");
            aGraph.AddVertex("G");
            aGraph.AddVertex("H");
            aGraph.AddVertex("I");
            aGraph.AddVertex("J");
            aGraph.AddVertex("K");
            aGraph.AddVertex("L");
            aGraph.AddVertex("M");
            aGraph.AddEdge(0, 1);
            aGraph.AddEdge(1, 2);
            aGraph.AddEdge(2, 3);
            aGraph.AddEdge(0, 4);
            aGraph.AddEdge(4, 5);
            aGraph.AddEdge(5, 6);
            aGraph.AddEdge(0, 7);
            aGraph.AddEdge(7, 8);
            aGraph.AddEdge(8, 9);
            aGraph.AddEdge(0, 10);
            aGraph.AddEdge(10, 11);
            aGraph.AddEdge(11, 12);
            aGraph.DepthFirstSearch();
            #endregion
            Console.ReadLine();
        }
    }
    public class Vertex
    {
        public bool wasVisted;
        public string label;
        public Vertex(string label)
        {
            this.label = label;
            wasVisted = false;
        }
    }
    public class Graph
    {
        private int NUM_VERTICES = 6;
        private Vertex[] vertices;
        private int[,] adjMatrix;
        int numVerts;
        public Graph(int numvertices)
        {
            NUM_VERTICES = numvertices;
            vertices = new Vertex[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j < NUM_VERTICES; j++)
            {
                for (int k = 0; k < NUM_VERTICES; k++)
                {
                    adjMatrix[j, k] = 0;
                }
            }
        }

        public void AddVertex(string label)
        {
            vertices[numVerts] = new Vertex(label);
            numVerts++;
        }

        public void AddEdge(int start ,int end)
        {
            adjMatrix[start, end] = 1;
        }

        public void ShowVertex(int v)
        {
            Console.Write(vertices[v].label + " ");
        }
        #region 拓扑排序
        //找到一个没有后继顶点的顶点
        //把此顶点添加到顶点列表内
        //从图中移除掉此顶点
        //重复直到移除所有

        //确定顶点是否有后继顶点
        public int NoSuccessors()
        {
            bool isEdge;
            for (int row = 0; row < NUM_VERTICES; row++)
            {
                isEdge = false;
                for (int col = 0; col < NUM_VERTICES; col++)
                {
                    if (adjMatrix[row, col] > 0)
                    {
                        isEdge = true;
                        break;
                    }
                }
                if (!isEdge)
                    return row;
            }
            return -1;
        }

        public void DelVertex(int vert)
        {
            if (vert != NUM_VERTICES - 1)
            {
                //从顶点列表中移除该顶点
                //从邻近矩阵中移除相应的行与列
                //邻近的行与列位置发生改变
                for (int j = vert; j < NUM_VERTICES-1; j++)
                {
                    vertices[j] = vertices[j + 1];
                }
                for (int row = vert; row <NUM_VERTICES-1 ; row++)
                {
                    MoveRow(row, NUM_VERTICES);
                }
                for (int col = vert; col < NUM_VERTICES-1; col++)
                {
                    MoveCol(col, NUM_VERTICES);
                }
            }
            NUM_VERTICES--;
        }

        private void MoveRow(int row,int length)
        {
            for (int col = 0; col < length; col++)
            {
                adjMatrix[row, col] = adjMatrix[row + 1, col];
            }
        }

        private void MoveCol(int col,int length)
        {
            for (int row = 0; row < length; row++)
            {
                adjMatrix[row, col] = adjMatrix[row, col + 1];
            }
        }

        public void TopSort()
        {
            Stack<string> gStack = new Stack<string>();
            while (NUM_VERTICES > 0)
            {
                int currVertex = NoSuccessors();
                if (currVertex == -1)
                {
                    Console.WriteLine($"Error: graph has cucles.");
                    return;
                }
                gStack.Push(vertices[currVertex].label);
                DelVertex(currVertex);
            }
            Console.WriteLine($"Topological sorting order: ");
            while (gStack.Count > 0)
            {
                Console.Write($"{gStack.Pop()} ");
            }
        }
        #endregion

        #region 深度优先搜索
        private int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < NUM_VERTICES; j++)
            {
                if (adjMatrix[v, j] == 1 && vertices[j].wasVisted == false)
                    return j;
            }
            return -1;
        }

        public void DepthFirstSearch()
        {
            Stack<int> gStack = new Stack<int>();
            vertices[0].wasVisted = true;
            ShowVertex(0);
            gStack.Push(0);
            int v;
            while (gStack.Count > 0)
            {
                v = GetAdjUnvisitedVertex(gStack.Peek());
                if (v == -1)
                {
                    Console.WriteLine($"{gStack.Peek()}");
                    gStack.Pop();
                }
                else
                {
                    vertices[v].wasVisted = true;
                    ShowVertex(v);
                    gStack.Push(v);
                }
            }
            for (int j = 0; j < NUM_VERTICES; j++)
            {
                vertices[j].wasVisted = false;
            }
        }
        #endregion
    }
}
