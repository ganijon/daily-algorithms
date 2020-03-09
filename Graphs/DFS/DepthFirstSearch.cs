using System;
using NUnit.Framework;
using Graphs.AdjacencyList;

namespace Graphs.DFS
{
    public class DepthFirstSearch
    {
        public bool Dfs(Graph graph, int target)
        {
            foreach (var node in graph.Nodes)
            {
                if (node.State == State.UNVISITED)
                {
                    bool targetFound = DfsVisit(node, target);
                    if (targetFound) return true;
                }
            }
            return false;
        }
        public bool DfsVisit(Node node, int target)
        {
            node.State = State.VISITING;

            // process node
            if (node.data == target) return true;

            foreach (var neigbor in node.Neigbors)
            {
                if (neigbor.State == State.UNVISITED)
                {
                    bool targetFound = DfsVisit(neigbor, target);
                    if (targetFound) return true;
                }
            }

            node.State = State.VISITED;
            return false;
        }
    }

    public class Tests
    {
        DepthFirstSearch dfs = new DepthFirstSearch();

        Graph graph = new Graph();

        Node node1 = new Node { data = 1 };
        Node node2 = new Node { data = 2 };
        Node node3 = new Node { data = 3 };
        Node node4 = new Node { data = 4 };

        [SetUp]
        public void Setup()
        {
            node1.Neigbors.Add(node2);
            node1.Neigbors.Add(node3);

            graph.Nodes.Add(node1);
            graph.Nodes.Add(node2);
            graph.Nodes.Add(node3);
            graph.Nodes.Add(node4);

            foreach (var node in graph.Nodes)
            {
                node.State = State.UNVISITED;
            }
        }

        [Test]
        public void Dfs()
        {
            Assert.IsTrue(dfs.Dfs(graph, 4));
            Assert.IsFalse(dfs.Dfs(graph, 5));
        }

        [Test]
        public void DfsVisit()
        {
            Assert.IsTrue(dfs.DfsVisit(node1, 2));
            Assert.IsTrue(dfs.DfsVisit(node1, 3));

            Assert.IsFalse(dfs.DfsVisit(node1, 0));
            Assert.IsFalse(dfs.DfsVisit(node4, 1));
        }
    }
}