using BreadthFirstSearch.Models;
using System;
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

                if(parsedAdjacency.Count != 2)
                {
                    Console.WriteLine($"INVALID ADJACENCY: {adjacency}, skipped.");
                    continue;
                }
                    
                var start = parsedAdjacency[0];
                var end = parsedAdjacency[1];

                try
                {
                    parsedNodes.Single(n => n.Name == start).Neighbors.TryAdd(end);
                    parsedNodes.Single(n => n.Name == end).Neighbors.TryAdd(start);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"DUPLICATE NODES: Exiting..");
                    Environment.Exit(0);
                }
            }
        }

        private static IEnumerable<string> ParseAdjacency(string adjacencentElement)
        {
            return adjacencentElement.Split("-").ToList();
        }
    }
}
