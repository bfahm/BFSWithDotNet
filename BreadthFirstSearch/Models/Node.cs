using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch.Models
{
    public class Node
    {
        public string Name { get; set; }
        public bool Visited { get; set; }
        public Node PreviousNode { get; set; }
        public List<string> Neighbors { get; set; } = new List<string>();

        public static Node FromName(string name) => new Node
        {
            Name = name
        };

        public static Node FromNameAndAdjacencies(string name, params string[] adjacencies) => new Node
        {
            Name = name,
            Neighbors = adjacencies.ToList()
        };

        public override string ToString()
        {
            return Name;
        }
    }
}
