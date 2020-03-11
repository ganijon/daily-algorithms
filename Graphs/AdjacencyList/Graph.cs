using System.Collections.Generic;
using NUnit.Framework;

namespace Graphs.AdjacencyList
{
    public class Graph
    {
        public List<Node> Nodes = new List<Node>();


        public void ResetState()
        {
            foreach (var node in Nodes)
            {
                node.State = State.UNVISITED;
            }
        }
    }

    public class Node
    {
        public int data;
        public State State = State.UNVISITED;
        public List<Node> Neigbors = new List<Node>();
    }

    public enum State { UNVISITED, VISITING, VISITED }
    public class Tests
    {
        [SetUp] public void Setup() { Assert.Pass(); }
    }
}