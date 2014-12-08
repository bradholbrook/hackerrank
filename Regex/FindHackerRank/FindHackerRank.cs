using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regex.FindHackerRank
{
    class FindHackerRank
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> lines = new List<String>(n);
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }
            FindHackerRanks(lines);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static void FindHackerRanks(List<String> lines)
        {
            System.Text.RegularExpressions.Regex starts = new System.Text.RegularExpressions.Regex(@"^hackerrank\b");
            System.Text.RegularExpressions.Regex ends = new System.Text.RegularExpressions.Regex(@"\bhackerrank$");
            bool atStart = false, atEnd= false;
            foreach(String line in lines)
            {
                atStart = starts.IsMatch(line);
                atEnd = ends.IsMatch(line);

                if(atStart && !atEnd)
                {
                    Console.WriteLine("1");
                    continue;
                }
                if(!atStart && atEnd)
                {
                    Console.WriteLine("2");
                    continue;
                }
                if(atStart && atEnd)
                {
                    Console.WriteLine("0");
                    continue;
                }
                Console.WriteLine("-1");
            }
        }
    }
}
