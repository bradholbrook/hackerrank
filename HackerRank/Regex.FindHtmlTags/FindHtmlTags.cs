using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.FindHtmlTags
{
    class FindHtmlTags
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> lines = new List<String>();
            for (int i = 0; i < n; i++) lines.Add(Console.ReadLine());

            FindTags(lines);
            Console.ReadLine();
        }
        static void FindTags(List<String> lines)
        {
            SortedSet<String> tagSet = new SortedSet<String>();
            //Find first occurence
            System.Text.RegularExpressions.Regex first = new System.Text.RegularExpressions.Regex(@"<[ ]*\b(\w+)\b[^>]*>");
            HashSet<String> possibles = new HashSet<string>();

            foreach (String line in lines)
            {
                System.Text.RegularExpressions.MatchCollection matches = first.Matches(line);
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    for(int i = 1; i < match.Groups.Count; i +=2)
                    {
                        possibles.Add(match.Groups[i].Value);
                    }
                }
                foreach (String possible in possibles)
                {
                    System.Text.RegularExpressions.Regex second = new System.Text.RegularExpressions.Regex(@"<[^<]*\b" + possible + @"\b[^<]*/[^<]*>|<[^<]*/[^<]*\b" + possible + @"\b[^<]*>");
                    if(second.IsMatch(line))
                    {
                        tagSet.Add(possible);
                    }
                }
            }
            string writestring = "";
            foreach(String s in tagSet)
            {
                writestring += s + ";";
            }
            Console.WriteLine(writestring.Substring(0, Math.Max(writestring.Length-1, 0)));
        }
    }
}
