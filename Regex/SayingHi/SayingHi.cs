using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.SayingHi
{
    class SayingHi
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> lines = new List<String>();
            for (int i = 0; i < n; i++) lines.Add(Console.ReadLine());

            SayHi(lines);
            Console.ReadLine();
        }
        static void SayHi(List<String> lines)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^hi(?i)\b.[^dD]");
            foreach (String line in lines)
            {
                if (pattern.IsMatch(line)) Console.WriteLine(line);
            }
        }
    }
}
