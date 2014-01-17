using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex.LanguageStrings
{
    class LanguageStrings
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<String> languages = new List<String>();
            for (int i = 0; i < n; i++)
            {
                System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^\d+\s");
                languages.Add(pattern.Replace(Console.ReadLine(), ""));
            }

            Validate(languages);
            Console.ReadLine();
        }
        static void Validate(List<String> languages)
        {
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(@"^(C|CPP|JAVA|PYTHON|PERL|PHP|RUBY|CSHARP|HASKELL|CLOJURE|BASH|SCALA|ERLANG|CLISP|LUA|BRAINFUCK|JAVASCRIPT|GO|D|OCAML|R|PASCAL|SBCL|DART|GROOVY|OBJECTIVEC)$");
            foreach (String language in languages)
            {
                if (pattern.IsMatch(language.ToUpper())) Console.WriteLine("VALID");
                else Console.WriteLine("INVALID");
            }
        }
    }
}
