using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.BritishAmericanSpelling
{
    class BritishAmericanSpelling
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            String data = "";
            for (int i = 0; i < n; i++)
            {
                data += Console.ReadLine();
                data += " ";
            }
            data.Replace("\n", " ");

            int t = Int32.Parse(Console.ReadLine());
            List<String> tests = new List<String>(n);
            for (int i = 0; i < t; i++)
            {
                tests.Add(Console.ReadLine());
            }
            FindSpellings(tests, data);
            Console.ReadLine();
        }
        static void FindSpellings(List<String> tests, string data)
        {
            foreach (String test in tests)
            {
                string american = test.Trim().Replace("our", "or");
                System.Text.RegularExpressions.Regex americanWord = new System.Text.RegularExpressions.Regex(@"\b" + american + @"\b");
                System.Text.RegularExpressions.Regex britishWord = new System.Text.RegularExpressions.Regex(@"\b" + test + @"\b");
                System.Text.RegularExpressions.MatchCollection usaMatch = americanWord.Matches(data);
                System.Text.RegularExpressions.MatchCollection ukMatch = britishWord.Matches(data);
                Console.WriteLine(usaMatch.Count + ukMatch.Count);
            }
        }
    }
}
