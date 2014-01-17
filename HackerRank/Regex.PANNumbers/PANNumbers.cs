using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.PANNumbers
{
    class PANNumbers
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> numbers = new List<String>();
            for (int i = 0; i < n; i++) numbers.Add(Console.ReadLine());

            Validate(numbers);
            Console.ReadLine();
        }
        static void Validate(List<String> numbers)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[A-Z]{5}\d{4}[A-Z]$");
            foreach (String num in numbers)
            {
                if (pattern.IsMatch(num)) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
        }
    }
}
