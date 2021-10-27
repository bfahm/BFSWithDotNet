using BreadthFirstSearch.Models;
using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    public class Printer
    {
        public static void PrintParsedNodes(IEnumerable<Node> nodes)
        {
            foreach(var node in nodes)
            {
                Console.WriteLine($"Name: {node.Name}");
                Console.WriteLine($"Neighbors: {string.Join(", ", node.Neighbors)}");
                Console.WriteLine();
            }
        }
    }
}
