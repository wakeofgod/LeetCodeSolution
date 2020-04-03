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
            //Graph aGraph = new Graph(13);
            //aGraph.AddVertex("A");
            //aGraph.AddVertex("B");
            //aGraph.AddVertex("C");
            //aGraph.AddVertex("D");
            //aGraph.AddVertex("E");
            //aGraph.AddVertex("F");
            //aGraph.AddVertex("G");
            //aGraph.AddVertex("H");
            //aGraph.AddVertex("I");
            //aGraph.AddVertex("J");
            //aGraph.AddVertex("K");
            //aGraph.AddVertex("L");
            //aGraph.AddVertex("M");
            //aGraph.AddEdge(0, 1);
            //aGraph.AddEdge(1, 2);
            //aGraph.AddEdge(2, 3);
            //aGraph.AddEdge(0, 4);
            //aGraph.AddEdge(4, 5);
            //aGraph.AddEdge(5, 6);
            //aGraph.AddEdge(0, 7);
            //aGraph.AddEdge(7, 8);
            //aGraph.AddEdge(8, 9);
            //aGraph.AddEdge(0, 10);
            //aGraph.AddEdge(10, 11);
            //aGraph.AddEdge(11, 12);
            //aGraph.DepthFirstSearch();
            #endregion

            #region 广度优先搜索
            //Graph aGraph = new Graph(13);
            //aGraph.AddVertex("A");
            //aGraph.AddVertex("B");
            //aGraph.AddVertex("C");
            //aGraph.AddVertex("D");
            //aGraph.AddVertex("E");
            //aGraph.AddVertex("F");
            //aGraph.AddVertex("G");
            //aGraph.AddVertex("H");
            //aGraph.AddVertex("I");
            //aGraph.AddVertex("J");
            //aGraph.AddVertex("K");
            //aGraph.AddVertex("L");
            //aGraph.AddVertex("M");
            //aGraph.AddEdge(0, 1);
            //aGraph.AddEdge(1, 2);
            //aGraph.AddEdge(2, 3);
            //aGraph.AddEdge(0, 4);
            //aGraph.AddEdge(4, 5);
            //aGraph.AddEdge(5, 6);
            //aGraph.AddEdge(0, 7);
            //aGraph.AddEdge(7, 8);
            //aGraph.AddEdge(8, 9);
            //aGraph.AddEdge(0, 10);
            //aGraph.AddEdge(10, 11);
            //aGraph.AddEdge(11, 12);
            //Console.WriteLine();
            //aGraph.BreadthFirstSearch();
            #endregion

            #region 最小生成树
            //Graph aGraph = new Graph(7);
            //aGraph.AddVertex("A");
            //aGraph.AddVertex("B");
            //aGraph.AddVertex("C");
            //aGraph.AddVertex("D");
            //aGraph.AddVertex("E");
            //aGraph.AddVertex("F");
            //aGraph.AddVertex("G");
            //aGraph.AddEdge(0, 1);
            //aGraph.AddEdge(0, 2);
            //aGraph.AddEdge(0, 3);
            //aGraph.AddEdge(1, 2);
            //aGraph.AddEdge(1, 3);
            //aGraph.AddEdge(1, 4);
            //aGraph.AddEdge(2, 3);
            //aGraph.AddEdge(2, 5);
            //aGraph.AddEdge(3, 5);
            //aGraph.AddEdge(3, 4);
            //aGraph.AddEdge(3, 6);
            //aGraph.AddEdge(4, 5);
            //aGraph.AddEdge(4, 6);
            //aGraph.AddEdge(5, 6);
            //Console.WriteLine();
            //aGraph.Mst();
            #endregion

            #region 测试 迪杰斯特拉算法
            Graph theGraph = new Graph();
            theGraph.AddVertex("A");
            theGraph.AddVertex("B");
            theGraph.AddVertex("C");
            theGraph.AddVertex("D");
            theGraph.AddVertex("E");
            theGraph.AddVertex("F");
            theGraph.AddVertex("G");
            theGraph.AddEdge(0, 1, 2);
            theGraph.AddEdge(0, 3, 1);
            theGraph.AddEdge(1, 3, 3);
            theGraph.AddEdge(1, 4, 10);
            theGraph.AddEdge(2, 5, 5);
            theGraph.AddEdge(2, 0, 4);
            theGraph.AddEdge(3, 2, 2);
            theGraph.AddEdge(3, 5, 8);
            theGraph.AddEdge(3, 4, 2);
            theGraph.AddEdge(3, 6, 4);
            theGraph.AddEdge(4, 6, 6);
            theGraph.AddEdge(6, 5, 1);
            Console.WriteLine();
            Console.WriteLine($"Shortest paths:");
            Console.WriteLine();
            theGraph.Path();
            Console.WriteLine();
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
    #region Graph 类：测试深度 广度的
    //public class Graph
    //{
    //    private int NUM_VERTICES = 6;
    //    private Vertex[] vertices;
    //    private int[,] adjMatrix;
    //    int numVerts;
    //    public Graph(int numvertices)
    //    {
    //        NUM_VERTICES = numvertices;
    //        vertices = new Vertex[NUM_VERTICES];
    //        adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
    //        numVerts = 0;
    //        for (int j = 0; j < NUM_VERTICES; j++)
    //        {
    //            for (int k = 0; k < NUM_VERTICES; k++)
    //            {
    //                adjMatrix[j, k] = 0;
    //            }
    //        }
    //    }

    //    public void AddVertex(string label)
    //    {
    //        vertices[numVerts] = new Vertex(label);
    //        numVerts++;
    //    }

    //    public void AddEdge(int start ,int end)
    //    {
    //        adjMatrix[start, end] = 1;
    //    }

    //    public void ShowVertex(int v)
    //    {
    //        Console.Write(vertices[v].label + " ");
    //    }
    //    #region 拓扑排序
    //    //找到一个没有后继顶点的顶点
    //    //把此顶点添加到顶点列表内
    //    //从图中移除掉此顶点
    //    //重复直到移除所有

    //    //确定顶点是否有后继顶点
    //    public int NoSuccessors()
    //    {
    //        bool isEdge;
    //        for (int row = 0; row < NUM_VERTICES; row++)
    //        {
    //            isEdge = false;
    //            for (int col = 0; col < NUM_VERTICES; col++)
    //            {
    //                if (adjMatrix[row, col] > 0)
    //                {
    //                    isEdge = true;
    //                    break;
    //                }
    //            }
    //            if (!isEdge)
    //                return row;
    //        }
    //        return -1;
    //    }

    //    public void DelVertex(int vert)
    //    {
    //        if (vert != NUM_VERTICES - 1)
    //        {
    //            //从顶点列表中移除该顶点
    //            //从邻近矩阵中移除相应的行与列
    //            //邻近的行与列位置发生改变
    //            for (int j = vert; j < NUM_VERTICES-1; j++)
    //            {
    //                vertices[j] = vertices[j + 1];
    //            }
    //            for (int row = vert; row <NUM_VERTICES-1 ; row++)
    //            {
    //                MoveRow(row, NUM_VERTICES);
    //            }
    //            for (int col = vert; col < NUM_VERTICES-1; col++)
    //            {
    //                MoveCol(col, NUM_VERTICES);
    //            }
    //        }
    //        NUM_VERTICES--;
    //    }

    //    private void MoveRow(int row,int length)
    //    {
    //        for (int col = 0; col < length; col++)
    //        {
    //            adjMatrix[row, col] = adjMatrix[row + 1, col];
    //        }
    //    }

    //    private void MoveCol(int col,int length)
    //    {
    //        for (int row = 0; row < length; row++)
    //        {
    //            adjMatrix[row, col] = adjMatrix[row, col + 1];
    //        }
    //    }

    //    public void TopSort()
    //    {
    //        Stack<string> gStack = new Stack<string>();
    //        while (NUM_VERTICES > 0)
    //        {
    //            int currVertex = NoSuccessors();
    //            if (currVertex == -1)
    //            {
    //                Console.WriteLine($"Error: graph has cucles.");
    //                return;
    //            }
    //            gStack.Push(vertices[currVertex].label);
    //            DelVertex(currVertex);
    //        }
    //        Console.WriteLine($"Topological sorting order: ");
    //        while (gStack.Count > 0)
    //        {
    //            Console.Write($"{gStack.Pop()} ");
    //        }
    //    }
    //    #endregion

    //    #region 深度优先搜索
    //    //查找指定顶点后 未访问的顶点
    //    private int GetAdjUnvisitedVertex(int v)
    //    {
    //        for (int j = 0; j < NUM_VERTICES; j++)
    //        {
    //            if (adjMatrix[v, j] == 1 && vertices[j].wasVisted == false)
    //                return j;
    //        }
    //        return -1;
    //    }

    //    public void DepthFirstSearch()
    //    {
    //        Stack<int> gStack = new Stack<int>();
    //        vertices[0].wasVisted = true;
    //        ShowVertex(0);
    //        gStack.Push(0);
    //        int v;
    //        while (gStack.Count > 0)
    //        {
    //            v = GetAdjUnvisitedVertex(gStack.Peek());
    //            if (v == -1)
    //            {
    //                Console.WriteLine($"{gStack.Peek()}");
    //                gStack.Pop();
    //            }
    //            else
    //            {
    //                vertices[v].wasVisted = true;
    //                ShowVertex(v);
    //                gStack.Push(v);
    //            }
    //        }
    //        for (int j = 0; j < NUM_VERTICES; j++)
    //        {
    //            vertices[j].wasVisted = false;
    //        }
    //    }
    //    #endregion

    //    #region 广度优先搜索
    //    //1.找到一个与当前顶点相邻的未访问过的顶点，把它标记为已访问的，
    //    //然后把它添加到队列中
    //    //2.如果找不到一个未访问过的相邻顶点，那么从队列中移除掉一个顶点，
    //    //把它当作当前顶点，然后重新开始
    //    //3.如果队列为空而无法执行第二步，算法结束
    //    public void BreadthFirstSearch()
    //    {
    //        Queue<int> gQueue = new Queue<int>();
    //        vertices[0].wasVisted = true;
    //        ShowVertex(0);
    //        gQueue.Enqueue(0);
    //        int vert1, vert2;
    //        while (gQueue.Count > 0)
    //        {
    //            vert1 = gQueue.Dequeue();
    //            vert2 = GetAdjUnvisitedVertex(vert1);
    //            while (vert2 != -1)
    //            {
    //                vertices[vert2].wasVisted = true;
    //                ShowVertex(vert2);
    //                gQueue.Enqueue(vert2);
    //                vert2 = GetAdjUnvisitedVertex(vert1);
    //            }
    //        }
    //        for (int i = 0; i < NUM_VERTICES; i++)               
    //        {
    //            vertices[i].wasVisted = false;
    //        }
    //    }
    //    #endregion

    //    #region 最小生成树
    //    //覆盖每个顶点(范围)所必须的最少数量的构造边
    //    //一张图可能有多个最小生成树
    //    //创建的最小生成树完全依赖于初始顶点

    //    public void Mst()
    //    {
    //        Stack<int> gStack = new Stack<int>();
    //        vertices[0].wasVisted = true;
    //        gStack.Push(0);
    //        int currVertex, ver;
    //        while (gStack.Count() > 0)
    //        {
    //            currVertex = gStack.Peek();
    //            ver = GetAdjUnvisitedVertex(currVertex);
    //            if (ver == -1)
    //            {
    //                gStack.Pop();
    //            }
    //            else
    //            {
    //                vertices[ver].wasVisted = true;
    //                gStack.Push(ver);
    //                ShowVertex(currVertex);
    //                ShowVertex(ver);
    //                Console.WriteLine();
    //            }
    //        }
    //        for (int i = 0; i < NUM_VERTICES; i++)
    //        {
    //            vertices[i].wasVisted = false;
    //        }
    //    }

    //    #endregion
    //}
    #endregion

    #region Graph类，查找最短路径，迪杰斯特拉算法
    public class Graph
    {
        private const int max_verts = 20;
        int infinity = 1000000;
        Vertex[] vertexList;
        int[,] adjMat;
        int nVerts;
        int nTree;
        DistOriginal[] sPath;
        int currentVert;
        int startToCurrent;
        public Graph()
        {
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            nVerts = 0;
            nTree = 0;
            for (int j = 0; j < max_verts; j++)
            {
                for (int k = 0; k < max_verts; k++)
                {
                    adjMat[j, k] = infinity;
                }
            }
            sPath = new DistOriginal[max_verts];
        }

        public void AddVertex(string lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }

        public void AddEdge(int start,int theEnd,int weight)
        {
            adjMat[start, theEnd] = weight;
        }

        public void Path()
        {
            int startTree = 0;
            vertexList[startTree].wasVisted = true;
            nTree = 1;
            for (int j = 0; j < nVerts; j++)
            {
                int tempDist = adjMat[startTree, j];
                sPath[j] = new DistOriginal(startTree, tempDist);
            }
            while (nTree < nVerts)
            {
                int indexMin = GetMin();
                int minDist = sPath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = sPath[indexMin].distance;
                vertexList[currentVert].wasVisted = true;
                nTree++;
                AdjustShortPath();
            }
            DisplayPaths();
            nTree = 0;
            for (int j = 0; j < nVerts; j++)
            {
                vertexList[j].wasVisted = false;
            }
        }

        public int GetMin()
        {
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 1; j < nVerts; j++)
            {
                if(!vertexList[j].wasVisted && sPath[j].distance < minDist)
                {
                    minDist = sPath[j].distance;
                    indexMin = j;
                }
            }
            return indexMin;
        }

        public void AdjustShortPath()
        {
            int column = 1;
            while (column < nVerts)
            {
                if (vertexList[column].wasVisted)
                {
                    column++;
                }
                else
                {
                    int currentToFringe = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFringe;
                    int sPathDist = sPath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        sPath[column].parentVert = currentVert;
                        sPath[column].distance = startToFringe;
                    }
                    column++;
                }
            }
        }

        public void DisplayPaths()
        {
            for (int j = 0; j < nVerts; j++)
            {
                Console.Write(vertexList[j].label + "=");
                if(sPath[j].distance==infinity)
                {
                    Console.Write("inf");
                }
                else
                {
                    Console.Write(sPath[j].distance);
                }
                string parent = vertexList[sPath[j].parentVert].label;
                Console.Write($"({parent}) ");
            }
        }

    }
    #endregion
    public class DistOriginal
    {
        public int distance;
        public int parentVert;
        public DistOriginal(int pv,int d)
        {
            distance = d;
            parentVert = pv;
        }
    }
}
