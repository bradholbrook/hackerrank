using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.LatitudeAndLongitude
{
    class Program
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
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^\([+-]?(((\d|[1-8]\d)(\.\d+)?)|(90(\.0+)?)), [+-]?((([1-9]?\d|1[0-7]\d)(\.\d+)?)|(180(\.0+)?))\)$");
            foreach (String num in numbers)
            {
                if (pattern.IsMatch(num)) Console.WriteLine("Valid");
                else Console.WriteLine("Invalid");
            }
        }
    }
}
