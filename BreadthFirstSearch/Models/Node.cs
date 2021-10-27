using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch.Models
{
    public class SimpleNode
    {
        public string Name { get; set; }

        public static SimpleNode FromName(string name) => new SimpleNode
        {
            Name = name
        };
    }

    public class Node : SimpleNode
    {
        public bool Visited { get; set; }
        public Node PreviousNode { get; set; }
        public List<SimpleNode> Neighbors { get; set; } = new List<SimpleNode>();

        public static new Node FromName(string name) => new Node
        {
            Name = name
        };

        public static Node FromSimpleNode(SimpleNode node) => new Node
        {
            Name = node.Name,
        };

        public static Node FromNameAndAdjacencies(string name, params string[] adjacencies) => new Node
        {
            Name = name,
            Neighbors = adjacencies.Select(a => SimpleNode.FromName(a)).ToList()
        };
    }
}
