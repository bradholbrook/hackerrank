using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.UtopianID
{
    class UtopianID
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> names = new List<String>();
            for (int i = 0; i < n; i++) names.Add(Console.ReadLine());

            Validate(names);
            Console.ReadLine();
        }
        static void Validate(List<String> names)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^[a-z]{0,3}\d{2,8}[A-Z]{3,}$");
            foreach (String name in names)
            {
                if (pattern.IsMatch(name)) Console.WriteLine("VALID");
                else Console.WriteLine("INVALID");
            }
        }
    }
}
