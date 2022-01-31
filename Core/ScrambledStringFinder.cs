using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal class ScrambledStringFinder
    {
        /// <summary>
        /// You are running a classroom and suspect that some of your students are 
        /// passing around the answers to multiple choice questions disguised as random strings.
        /// 
        /// Your task is to write a function that, given a list of words and a string, 
        /// finds and returns the word in the list that is scrambled up inside the string, 
        /// if any exists.There will be at most one matching word.
        /// The letters don't need to be in order or next to each other. The letters cannot be reused.
        /// </summary>
        /// <param name="scrambledText">A string which will be searched for the possible words.</param>
        /// <param name="possibleWords">A list of words that can appear in the scrambled text. 
        /// No more than one of these words will be contained there.</param>
        /// <returns>Returns the word from possibleWords which was found in the scrambled text,
        /// or null if no word was found.</returns>
        internal static string FindScrambledWord(string scrambledText, string[] possibleWords)
        {
            return null;
        }
    }
}
