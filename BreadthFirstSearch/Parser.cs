using BreadthFirstSearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace BreadthFirstSearch
{
    public class Parser
    {
        public static List<Node> Parse(string nodes, string adjacencies)
        {
            var parsedNodes = ParseNodes(nodes);
            ParseAdjacencies(adjacencies, parsedNodes);

            return parsedNodes;
        }

        protected static List<Node> ParseNodes(string nodesInput)
        {
            var cleanedInput = nodesInput.Clean();
            var nodeNames = cleanedInput.Split(",");
            return nodeNames.Select(n => Node.FromName(n)).ToList();
        }

        protected static void ParseAdjacencies(string adjacenciesInput, List<Node> parsedNodes)
        {
            var cleanedInput = adjacenciesInput.Clean();

            var adjacencies = cleanedInput.Split(",");

            foreach (var adjacency in adjacencies)
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
