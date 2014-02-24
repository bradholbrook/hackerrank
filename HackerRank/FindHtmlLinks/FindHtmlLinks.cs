using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHtmlLinks
{
    class FindHtmlLinks
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> lines = new List<String>();
            List<String> splitLine = new List<String>();
            for (int i = 0; i < n; i++)
            {
                splitLine = System.Text.RegularExpressions.Regex.Split(Console.ReadLine(), @"<a").ToList();
                foreach (String line in splitLine)
                    lines.Add(line);
            }

            FindLinks(lines);
            Console.ReadLine();
        }
        static void FindLinks(List<String> lines)
        {
            SortedSet<String> tagSet = new SortedSet<String>();
            //Find first occurence
            System.Text.RegularExpressions.Regex first = new System.Text.RegularExpressions.Regex(@"href=[^""]*""(?<link>[^""]+)"".*>(?<name>[^<>/]*)</a>");
            foreach (String line in lines)
            {
                System.Text.RegularExpressions.MatchCollection matches = first.Matches(line);
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    Console.Write(match.Groups["link"].Value.Trim() + ",");
                    Console.Write(match.Groups["name"].Value.Trim() + "\n");
                }
            }
        }
    }
}
