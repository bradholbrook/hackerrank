using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.FindWord
{
    class FindWord
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            String data = "";
            for (int i = 0; i < n; i++)
            {
                data += " " + Console.ReadLine();
            }
            //As it turns out, \W matches things that aren't a-z0-9_
            //e.g. if we had (test) test_nottest, there is 1 occurence of test
            //If we split on \W and recombine we will have \stest\stest_nottest where test is surrounded by spaces for each occurence
            String[] words = System.Text.RegularExpressions.Regex.Split(data, @"\W");
            data = "";
            foreach(string s in words)
            {
                if(!String.IsNullOrWhiteSpace(s))
                    data += " " + s;
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
                System.Text.RegularExpressions.Regex words = new System.Text.RegularExpressions.Regex(String.Format(@"\b{0}\b", test));
                System.Text.RegularExpressions.MatchCollection matches = words.Matches(data);
                Console.WriteLine(matches.Count);
            }
        }
    }
}
