using Graphs.AdjacencyList;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.BFS
{
    public class BreadthFirstSearch
    {
        Queue<Node> q;

        public Node Bfs(Graph g, int target)
        {
            g.ResetState();

            foreach (var node in g.Nodes)
            {
                if (node.State == State.UNVISITED)
                {
                    var targetFound = BfsVisit(node, target);

                    if (targetFound != null)
                        return targetFound;
                }
            }

            return null;
        }

        public Node BfsVisit(Node start, int x)
        {
            q = new Queue<Node>();

            q.Enqueue(start);
            start.State = State.VISITING;

            while (q.Count != 0)
            {
                var node = q.Dequeue();

                if (node.data == x)
                    return node;

                foreach (var neighbor in node.Neigbors)
                {
                    q.Enqueue(neighbor);
                    neighbor.State = State.VISITING;
                }

                node.State = State.VISITED;
            }

            return null;
        }
    }

    public class Tests
    {
        BreadthFirstSearch bfs;
        Node node1, node2, node3, node4;
        Graph graph;


        [SetUp]
        public void Setup()
        {
            bfs = new BreadthFirstSearch();

            graph = new Graph();

            node1 = new Node { data = 1 };
            node2 = new Node { data = 2 };
            node3 = new Node { data = 3 };
            node4 = new Node { data = 4 };

            node1.Neigbors.Add(node2);
            node1.Neigbors.Add(node3);
            node2.Neigbors.Add(node3);

            graph.Nodes.AddRange(new[] { node1, node2, node3, node4 });
        }

        [Test]
        public void Bfs()
        {
            Assert.AreEqual(node1, bfs.BfsVisit(node1, 1));
            Assert.AreEqual(node2, bfs.BfsVisit(node1, 2));
            Assert.AreEqual(node3, bfs.BfsVisit(node1, 3));
            Assert.AreEqual(null, bfs.BfsVisit(node4, 2));
            Assert.AreEqual(null, bfs.BfsVisit(node3, 2));

            Assert.AreEqual(node1, bfs.Bfs(graph, 1));
        }
    }
}