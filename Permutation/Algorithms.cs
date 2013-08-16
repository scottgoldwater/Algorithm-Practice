using System;
using System.Collections.Generic;
using System.Text;

namespace Permutation
{
    /// <summary>
    /// Practice recursive algorithms for interviews
    /// </summary>
    class Algorithms
    {
        static void Main()
        {
            Console.WriteLine("This is a string".ReverseWordsInString());
            Console.Read();
        }

        /// <summary>
        /// Initializes the permutation recursive method 
        /// </summary>
        /// <param name="input">The input.</param>
        /// <exception cref="System.ArgumentNullException">input</exception>
        static void PermInit(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            StringBuilder output = new StringBuilder();
            bool[] check = new bool[input.Length];
            Perm(check, input, output, 0);
            Console.ReadLine();
        }

        /// <summary>
        /// Recursive permutation function 
        /// </summary>
        /// <param name="check">The used array</param>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        /// <param name="pos">The current position</param>
        static void Perm(bool[] check, string input, StringBuilder output, int pos)
        {
            if (pos == input.Length)
            {
                Console.WriteLine(output);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if(check[i])
                    continue;
                output.Append(input[i]);
                check[i] = true;
                Perm(check,input,output,pos+1);
                check[i]=false;
                output.Remove(output.Length-1,1);
            }
        }


        /// <summary>
        /// Initializes the combination method
        /// </summary>
        /// <param name="input">The input.</param>
        static void CombInit(string input)
        {
            StringBuilder output = new StringBuilder();
            Comb(input, output,0);
            Console.ReadLine();
        }



        /// <summary>
        /// Combination recursive algorithm 
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="output">The output</param>
        /// <param name="position">The current position</param>
        static void Comb(string input, StringBuilder output, int position)
        {
            if (position == input.Length)
                return;

            for (int i = position; i < input.Length; i++ )
            {
                output.Append(input[i]);
                Console.WriteLine(output);
                Comb(input, output, i+1);
                output.Remove(output.Length-1, 1);
            }
        }

        /// <summary>
        /// Initializes alpha numeric phone mapping algorithm 
        /// </summary>
        /// <param name="input">The input.</param>
        static void PhoneInit(string input)
        {
            Dictionary<char, string> phoneDictionary = new Dictionary<char, string>
            {
                {'2', "ABC"},
                {'3', "DEF"},
                {'4', "GHI"},
                {'5', "JKL"},
                {'6', "MNO"},
                {'7', "PQRS"},
                {'8', "TUV"},
                {'9', "WXYZ"}
            };

            StringBuilder output = new StringBuilder();

            Phone(output,input,phoneDictionary,0);
            Console.ReadLine();
        }

        /// <summary>
        /// Recursive algorithm for key alpha phone number mappings 
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="phoneDictionary">The phone dictionary of mapped keys</param>
        /// <param name="digit">The current digit</param>
        static void Phone(StringBuilder output, string input, Dictionary<char,string> phoneDictionary, int digit)
        {
            if (digit == input.Length)
            {
                Console.WriteLine(output +"\n");
                return;
            }

            if (!phoneDictionary.ContainsKey(input[digit]))
            {
                output.Append(input[digit]);
                Phone(output, input, phoneDictionary, digit + 1);
                output.Remove(output.Length - 1, 1);
                return;
            }

            string digitMap = phoneDictionary[input[digit]];

            for (int i = 0; i <digitMap.Length ; i++)
            {
                output.Append(digitMap[i]);
                Phone(output,input,phoneDictionary,digit+1);
                output.Remove(output.Length - 1, 1);
            }
            
        }
    }
}
