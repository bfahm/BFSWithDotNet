using System;
using System.Linq;

namespace BreadthFirstSearch
{
    class Program
    {
        private static bool demoMode = false;

        static void Main(string[] args)
        {
            PrintIntro();
            SetDemoMode(args);

            Console.WriteLine("Insert Nodes, each separated by a comma:");
            string nodes = CustomReadLine("0,1,2,3,4,5,6");

            Console.WriteLine("Insert Adjacencies, each separated by a comma, start and end separated by hyphen '-',");
            Console.WriteLine("Example: 'X-Y, Y-Z'");
            string adjacencies = CustomReadLine("0-1,0-3,1-3,1-2,1-6,1-5,3-1,3-2,3-4,3-0,2-5,2-5,4-6,4-3,2-4");
            
            Console.WriteLine("------------------------");
            Console.WriteLine();

            var parsedNodes = Parser.Parse(nodes, adjacencies);
            Printer.PrintParsedNodes(parsedNodes);
            
            Console.WriteLine("------------------------");
            Console.WriteLine();

            var bfs = new Engine(parsedNodes);
            bfs.Discover();
            Console.WriteLine(bfs.Solve());
        }

        static void PrintIntro()
        {
            Console.WriteLine("[[Breadth First Search]]");
            Console.WriteLine("");
        }

        static void SetDemoMode(string[] args)
        {
            var index = Array.FindIndex(args, e => e == "-demo");
            if (index != -1 && args[index + 1] == "on")
            {
                demoMode = true;
                Console.WriteLine("DEMO MODE: ON..");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        static string CustomReadLine(string demoString = null)
        {
            if (demoString != null && demoMode)
            {
                Console.WriteLine(demoString);
                return demoString;
            }
            else
                return Console.ReadLine();
        }
    }
}
