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
            }
            data.Replace("\n"," ");

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
                System.Text.RegularExpressions.Regex spelling = new System.Text.RegularExpressions.Regex(@"ze$");
                string british = spelling.Replace(test, "se");
                System.Text.RegularExpressions.Regex americanWord = new System.Text.RegularExpressions.Regex(test);
                System.Text.RegularExpressions.Regex britishWord = new System.Text.RegularExpressions.Regex(british);
                System.Text.RegularExpressions.MatchCollection usaMatch = americanWord.Matches(data);
                System.Text.RegularExpressions.MatchCollection ukMatch = britishWord.Matches(data);
                Console.WriteLine(usaMatch.Count + ukMatch.Count);
            }
        }
    }
}
