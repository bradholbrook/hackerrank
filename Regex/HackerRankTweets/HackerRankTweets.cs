using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.HackerRankTweets
{
    class HackerRankTweets
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> tweets = new List<String>(n);
            for (int i = 0; i < n; i++)
            {
                tweets.Add(Console.ReadLine());
            }
            MatchTweets(tweets);
            Console.ReadLine();
        }
        static void MatchTweets(List<String> tweets)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"(?i)hackerrank");
            int count = 0;
            foreach (String tweet in tweets)
                if (pattern.IsMatch(tweet)) count++;
            Console.WriteLine(count);
        }
    }
}
