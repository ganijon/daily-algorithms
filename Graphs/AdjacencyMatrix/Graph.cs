using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Graphs.AdjacencyMatrix
{
    public class Graph
    {
        bool[,] adjMatrix;

        public Graph(int v)
        {
            adjMatrix = new bool[v, v];
        }

        public void AddEdge(int i, int j)
        {
            adjMatrix[i, j] = true;
            adjMatrix[j, i] = true;
        }
        public void RemoveEdge(int i, int j)
        {
            adjMatrix[i, j] = false;
            adjMatrix[j, i] = false;
        }
        public bool IsEdge(int i, int j)
        {
            return adjMatrix[i, j];
        }

        public override string ToString()
        {
            var s = new StringBuilder("TEST OUTPUT:");
            for (int i = 0; i < adjMatrix.Rank; i++)
            {
                s.Append($"{i}:");
                for (int j = 0; j < adjMatrix.GetLength(i); j++)
                {
                    s.Append((adjMatrix[i, j] ? 1 : 0) + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }

    }

    public class Tests
    {

        private Graph graph;

        [SetUp]
        public void Setup()
        {
            graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            Console.WriteLine(graph.ToString());
            Debug.WriteLine(graph.ToString());
            Trace.WriteLine(graph.ToString());
        }

        [Test]
        public void AddEdge()
        {
            graph.AddEdge(0, 3);
            Assert.IsTrue(graph.IsEdge(0, 3));
        }

        [Test]
        public void IsEdge()
        {
            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsTrue(graph.IsEdge(0, 2));

            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(1, 3));
        }

        [Test]
        public void RemoveEdge()
        {
            graph.RemoveEdge(0, 1);
            Assert.IsFalse(graph.IsEdge(0, 1));
        }
    }
}