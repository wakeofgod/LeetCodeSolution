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
    }
}
