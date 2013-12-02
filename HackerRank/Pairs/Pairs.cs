using System;
using System.Collections.Generic;
using System.Text;

namespace Pairs
{
    class Pairs
    {
        static int pairs(int[] a, int k)
        {
            int count = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                dict.Add(a[i], a[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (dict.ContainsKey(a[i] + k))
                    count++;
            }
            return count;
        }
        // Taken from Problem statement
        static void Main(String[] args)
        {
            int res;
            
            String line = Console.ReadLine();
            String[] line_split = line.Split(' ');
            int _a_size = Convert.ToInt32(line_split[0]);
            int _k = Convert.ToInt32(line_split[1]);
            int[] _a = new int[_a_size];
            int _a_item;
            String move = Console.ReadLine();
            String[] move_split = move.Split(' ');
            for (int _a_i = 0; _a_i < move_split.Length; _a_i++)
            {
                _a_item = Convert.ToInt32(move_split[_a_i]);
                _a[_a_i] = _a_item;
            }

            res = pairs(_a, _k);
            Console.WriteLine(res);

        }
    }
}
