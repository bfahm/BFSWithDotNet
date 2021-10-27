using System.Collections.Generic;
using System.Linq;

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
        public static void TryAdd(this List<string> list, string toBeAdded)
        {
            var listAlreadyContainsNode = list.Any(l => l == toBeAdded);
            if (!listAlreadyContainsNode)
                list.Add(toBeAdded);
        }
    }
}
