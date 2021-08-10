using System;
using System.Collections.Generic;

namespace Palindromable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cases = { "?ab??a", "bab??a", "?a?", "a?a", "?ab???a" };

            Dictionary<string, string> TestCases = new Dictionary<string, string>
            {
                {
                    "?ab??a","aabbaa"
                },
                {
                    "bab??a","NO"
                },
                {
                    "?a?","aaa"
                },
                {
                    "a?a","aaa"
                },
                {
                    "?ab???a","aababaa"
                },
                {
                    "B?B","bab"
                },
                {
                    "Abanico","NO"
                },
                {
                    "????????","aaaaaaaa"
                },
            };

            foreach (var Case in TestCases)
            {
                var result = Solution(Case.Key);
                Console.WriteLine($"{result.ToUpper() == Case.Value.ToUpper()} for \"{Case.Key}\", received: {result}");
            }
        }

        static string Solution(string S)
        {
            char[] chars = S.ToLower().ToCharArray();
            for (int leftIndex =0,rightIndex = chars.Length - 1; leftIndex < chars.Length; leftIndex++, rightIndex--)
            {

                if (chars[leftIndex] != chars[rightIndex] && !(chars[leftIndex] == '?' || chars[rightIndex] == '?') )
                {
                    return "NO";
                }
                
                if (chars[leftIndex] == '?' && chars[rightIndex] == '?')
                {
                    chars[leftIndex] = 'a';
                    chars[rightIndex] = 'a';
                    continue;
                }
                
                chars[leftIndex] = chars[leftIndex] == '?' ? chars[rightIndex] : chars[leftIndex];
                chars[rightIndex] = chars[rightIndex] == '?' ? chars[leftIndex] : chars[rightIndex];
                
            }
            return new string(chars);
        }
    }
}
