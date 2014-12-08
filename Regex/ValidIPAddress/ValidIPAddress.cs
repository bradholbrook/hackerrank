using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.ValidIPAddress
{
    class ValidIPAddress
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> addresses = new List<String>();
            for (int i = 0; i < n; i++) addresses.Add(Console.ReadLine());

            ValidateAddresses(addresses);
            Console.ReadLine();
        }
        static void ValidateAddresses(List<String> addresses)
        {
            System.Text.RegularExpressions.Regex ipv4
             = new System.Text.RegularExpressions.Regex(@"^((\d|\d{2}|[01]\d{2}|2[0-4]\d|25[0-5])\.){3}(\d|\d{2}|[01]\d{2}|2[0-4]\d|25[0-5])$");
            System.Text.RegularExpressions.Regex ipv6
             = new System.Text.RegularExpressions.Regex(@"^([\da-f]{1,4}:){7}[\da-f]{1,4}$");
            foreach(String addr in addresses)
            {
                if (ipv4.IsMatch(addr))
                {
                    Console.WriteLine("IPv4");
                    continue;
                }
                if (ipv6.IsMatch(addr))
                {
                    Console.WriteLine("IPv6");
                    continue;
                }
                Console.WriteLine("Neither");
            }
        }
    }
}
