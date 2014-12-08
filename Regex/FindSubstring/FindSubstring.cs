using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.FindSubstring
{
    class FindSubstring
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            String data = "";
            for (int i = 0; i < n; i++)
            {
                data += " " + Console.ReadLine();
            }
            
            int t = Int32.Parse(Console.ReadLine());
            List<String> tests = new List<String>(n);
            for (int i = 0; i < t; i++)
            {
                tests.Add(Console.ReadLine().Trim());
            }
            FindWords(tests, data);
            Console.ReadLine();
        }
        static void FindWords(List<String> tests, string data)
        {
            foreach (String test in tests)
            {
                System.Text.RegularExpressions.Regex words = new System.Text.RegularExpressions.Regex(String.Format(@"\w{0}\w", test));
                System.Text.RegularExpressions.MatchCollection matches = words.Matches(data);
                Console.WriteLine(matches.Count);
            }
        }
    }
}
