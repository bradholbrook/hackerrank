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
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^<(\w+)>.*${1}");
            foreach (String line in lines)
            {
                System.Text.RegularExpressions.MatchCollection matches = pattern.Matches(line);
                foreach(System.Text.RegularExpressions.Match match in matches)
                {
                    tagSet.Add(match.Groups["1"].Value);
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
