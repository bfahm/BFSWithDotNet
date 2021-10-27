using BreadthFirstSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public static class StringUtils
    {
        public static string Clean(this string someString)
        {
            return someString.Replace(" ", "");
        }
    }

    public static class ListUtils
    {
        public static void TryAdd(this List<SimpleNode> list, SimpleNode toBeAdded)
        {
            var listAlreadyContainsNode = list.Any(l => l.Name == toBeAdded.Name);
            if (!listAlreadyContainsNode)
                list.Add(toBeAdded);
        }
    }
}
