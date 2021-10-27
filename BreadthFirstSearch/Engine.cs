using BreadthFirstSearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
    public class Engine
    {
        private Queue<Node> mainQueue;
        private Node startingNode;
        private Node endingNode;
        private readonly List<Node> allNodes;

        public Engine(List<Node> allNodes)
        {
            this.allNodes = allNodes;

            mainQueue = new Queue<Node>();

            startingNode = allNodes.First();
            endingNode = allNodes.Last();
        }

        public void Discover()
        {
            VisitNode(startingNode);

            while(mainQueue.TryDequeue(out Node currentNode))
            {
                // Get neighbor as a node from allNodes (instead of using simple string)
                var neighbors = allNodes.Where(n => currentNode.Neighbors.Any(cn => cn == n.Name)).ToList();

                foreach(var neighbor in neighbors)
                {
                    if (!neighbor.Visited)
                    {
                        VisitNode(neighbor, currentNode);
                    }
                }
            }
        }

        public string Solve()
        {
            var nearestPath = new List<string>();

            nearestPath.Add(endingNode.Name);

            var previousNode = endingNode.PreviousNode;
            
            while (previousNode != null)
            {
                nearestPath.Add(previousNode.Name);

                previousNode = previousNode.PreviousNode;
            }

            if (nearestPath.Count == 1)
                return "No Path";
            else
            {
                nearestPath.Reverse();
                return string.Join("-", nearestPath);
            }
        }

        private void VisitNode(Node node, Node previousNode = null)
        {
            node.PreviousNode = previousNode;
            node.Visited = true;

            mainQueue.Enqueue(node);
        }
    }
}
