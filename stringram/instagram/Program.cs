using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stringram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string (Escape to exit):");
            do
            {
                var word = Console.ReadLine();
                var result = GetInstaGram(word);
                Console.WriteLine(result);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        private static string GetInstaGram(string word)
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            word = rgx.Replace(word, "");

            int minFrequency = int.MaxValue;
            int maxFrequency = int.MinValue;

            while (word.Length > 0)
            {
                var count = word.Count(x => x == word[0]);
                if (maxFrequency < count)
                {
                    maxFrequency = count;
                }
                if (minFrequency > count)
                {
                    minFrequency = count;
                }
                word = word.Replace(word[0].ToString(), String.Empty);

                if (minFrequency != maxFrequency)
                    return "NOTAGRAM";
            }

            if (minFrequency == 1 && maxFrequency == 1) 
                return "HETEROGRAM";

            else if (minFrequency == maxFrequency)
                return "ISOGRAM";

            return "";
        }
    }
}
