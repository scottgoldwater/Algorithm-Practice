using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation
{
    static class ReverseString
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
    }
}
