using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.SplitPhoneNumbers
{
    class SplitPhoneNumbers
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> numbers = new List<String>();
            for (int i = 0; i < n; i++) numbers.Add(Console.ReadLine());

            SplitNumbers(numbers);
            Console.ReadLine();
        }
        static void SplitNumbers(List<String> numbers)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^(?<country>\d{1,3})[-\s](?<area>\d{1,3})[-\s](?<number>\d{4,10})$");
            foreach (String number in numbers)
            {
                System.Text.RegularExpressions.Match match = pattern.Match(number);
                Console.WriteLine(String.Format("CountryCode={0},LocalAreaCode={1},Number={2}", match.Groups["country"].Value, match.Groups["area"].Value, match.Groups["number"].Value));
            }
        }
    }
}

