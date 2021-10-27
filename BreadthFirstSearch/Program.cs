using System;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Nodes:");
            string nodes = Console.ReadLine();

            Console.WriteLine("Insert Adjacencies:");
            string adjacencies = Console.ReadLine();
            
            Console.WriteLine("------------------------");
            Console.WriteLine();

            var parsedNodes = Parser.Parse(nodes, adjacencies);
            Printer.PrintParsedNodes(parsedNodes);
        }
    }
}
