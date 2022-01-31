using Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class WhenFindingScrambledWords
    {
        private string[] _possibleWords = new[] { "cat", "baby", "dog", "bird", "car", "ax" };

        [TestCase("tcabnihjs", "cat")]
        [TestCase("tbcanihjs", "cat")]
        [TestCase("bbabylkkj", "baby")]
        [TestCase("breadmaking", "bird")]
        public void ShouldFindScrambledWord(string input, string word)
        {
            Assert.AreEqual(word, ScrambledStringFinder.FindScrambledWord(input, _possibleWords));
        }

        [TestCase("baykkjl")]
        [TestCase("ccc")]
        public void ShouldReturnNull(string input)
        {
            Assert.Null(ScrambledStringFinder.FindScrambledWord(input, _possibleWords));
        }
    }
}
