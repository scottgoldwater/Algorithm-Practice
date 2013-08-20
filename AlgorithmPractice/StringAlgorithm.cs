using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    static class StringAlgorithm
    {

        /// <summary>
        /// Easy Reverse 
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ReverseEasy(this string input)
        {
            return new string(input.Reverse().ToArray());
        }

        /// <summary>
        /// Naive Reverse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ReverseNaive(this string input)
        {
            char[] stringArray = input.ToCharArray();
            for (int i = 0; i < input.Length/2; i++)
            {
                char temp = stringArray[i];
                stringArray[i] = stringArray[input.Length - 1 - i];
                stringArray[input.Length-1-i] = temp;
            }

            return new string(stringArray);
        }

        /// <summary>
        /// The best reversal method
        /// </summary>
        /// <param name="input">The input</param>
        /// <returns></returns>
        public static string BestReverse(this string input)
        {
            char[] stringArray = input.ToCharArray();
            
            for (int i = 0; i < input.Length/2; i++)
            {
                stringArray[i] ^= stringArray[input.Length-1-i];
                stringArray[input.Length - 1 - i] ^= stringArray[i];
                stringArray[i] ^= stringArray[input.Length - 1 - i];
            }

            return new string(stringArray);
        }

        public static string CompressString(this string input)
        {
            StringBuilder output = new StringBuilder();
            char[] inputArray = input.ToCharArray();
            char current = inputArray[0];
            int number = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (current == inputArray[i])
                {
                    number++;
                }
                else
                {
                    output.Append(string.Format("{0}{1}", number, current));
                    number = 1;
                    current = inputArray[i];
                }
                
            }

            output.Append(string.Format("{0}{1}", number, current));

            return output.ToString();
        }

        public static string ReverseWordsInString(this string input)
        {
            string[] wordStrings = input.Split(' ');

            for (int i = 0; i<wordStrings.Length;i++)
            {
                char[] wordArray = wordStrings[i].ToCharArray();
                
                for (int j = 0; j < wordArray.Length/2; j++)
                {
                    wordArray[j] ^= wordArray[wordArray.Length - 1-j];
                    wordArray[wordArray.Length - 1-j] ^= wordArray[j];
                    wordArray[j] ^= wordArray[wordArray.Length - 1-j];
                }
                wordStrings[i] = new string(wordArray);
            }

            return string.Join(" ", wordStrings);
        }



        public static int StringSearchAgain(string needle, string haystack)
        {
            if(string.IsNullOrEmpty(needle) || string.IsNullOrEmpty(haystack))
                throw new ArgumentNullException("Problem with args");

            int current = needle.Length;
            for (int i = 0; i < needle.Length; i++)
            {
                for (int j = 0; j < haystack.Length; j++)
                {
                    if (current == 0)
                        return j-needle.Length;

                    if (needle[i] == haystack[j])
                    {
                        ++i;
                        current--;
                        continue;
                    }
                    i = 0;
                    current = needle.Length;
                }
                return -1;
            }
            return -1;
        }


        public static bool SearchSearch(string needle, string haystack)
        {
            if(string.IsNullOrEmpty(needle) || string.IsNullOrEmpty(haystack))
                throw new ArgumentNullException("");

            int i = 0;
            for (int j = 0; j < haystack.Length; j++)
            {
                if (i== needle.Length)
                    return true;
                    
                if (haystack[j] == needle[i])
                {
                    i++;
                    continue;
                }
                i = 0; 
            }
            return false;
        }
    }
}
