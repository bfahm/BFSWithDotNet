using BreadthFirstSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Parser
    {
        public static void Parse(string nodes, string adjacencies)
        {

        }

        protected static IEnumerable<Node> ParseNodes(string nodesInput)
        {
            var cleanedInput = nodesInput.Clean();
            var nodeNames = cleanedInput.Split(",");
            return nodeNames.Select(n => Node.FromName(n));
        }

        protected static void ParseAdjacencies(string adjacenciesInput, IEnumerable<Node> parsedNodes)
        {
            var cleanedInput = adjacenciesInput.Clean();

            var adjacencies = cleanedInput.Split(",");
            
            foreach(var adjacency in adjacencies)
            {
                var parsedAdjacency = ParseAdjacency(adjacency).ToList();
                var start = parsedAdjacency[0];
                var end = parsedAdjacency[1];

                parsedNodes.Single(n => n.Name == start).Neighbors.TryAdd(end);
                parsedNodes.Single(n => n.Name == end).Neighbors.TryAdd(start);
            }
        }

        private static IEnumerable<string> ParseAdjacency(string adjacencentElement)
        {
            return adjacencentElement.Split("-").ToList();
        } 
    }
}
