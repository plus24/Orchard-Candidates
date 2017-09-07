using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your word (Escape to exit):");
            do
            {
                var word = Console.ReadLine();

                #region firstmethod
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var palindromeExpensiveResult = PalindromeStringExpensive(word);
                watch.Stop();
                var FirstelapsedMs = watch.ElapsedTicks;
                #endregion

                #region secondmethod
                watch.Reset();
                watch.Start();

                var palindromeCheapResult = PalindromeStringCheap(word);

                watch.Stop();
                var SecondelapsedMs = watch.ElapsedTicks;
                #endregion

                Console.WriteLine(palindromeExpensiveResult + " Cost=" + FirstelapsedMs);
                Console.WriteLine(palindromeCheapResult + " Cost=" + SecondelapsedMs);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static string PalindromeStringExpensive(string word)
        {
            word = ValidateWord(word);

            if (string.IsNullOrEmpty(word))
            {
                return "UNDETERMINED";
            }

            var length = (int)Math.Ceiling((double)word.Length / 2);

            string ltrWord = word.Substring(0, length);
            string rtlWord = word.Substring(word.Length / 2, length);

            char[] rtlWordCharArray = rtlWord.ToCharArray();

            Array.Reverse(rtlWordCharArray);

            rtlWord = new string(rtlWordCharArray);

            //Console.WriteLine();

            if (ltrWord == rtlWord)
            {
                return "TRUE";
            }
            else
            {
                return "FALSE";
            }
        }


        private static string PalindromeStringCheap(string word)
        {
            word = ValidateWord(word);

            if (string.IsNullOrEmpty(word))
                return "UNDETERMINED";

            int leftCoursor = 0;
            int rightCoursor = word.Length - 1;
            while (true)
            {
                if (leftCoursor > rightCoursor)
                    break;
                else if (word.Substring(leftCoursor, 1) != word.Substring(rightCoursor, 1))
                    return "FALSE";
                leftCoursor++;
                rightCoursor--;
            }
            return "TRUE";
        }


        private static string ValidateWord(string word)
        {
            Regex rgx = new Regex("[^a-zA-Z]");
            word = rgx.Replace(word, "");
            return word.ToLower();
        }
    }
}
