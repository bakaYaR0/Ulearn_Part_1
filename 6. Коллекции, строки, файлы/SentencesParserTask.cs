using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        static char[] spliters = new char[] { '.', '!', '?', ';', ':', '(', ')' };

        public static List<List<string>> ParseSentences(string text)
        {
            text = text.ToLower();
            List<List<string>> sentences = new List<List<string>>();
            string[] sentencesArray = text.Split(spliters);

            foreach (var sentence in sentencesArray)
            {
                List<string> words = new List<string>();
                var sentenceCleared = ClearSentence(sentence);

                string[] wordArrray = sentenceCleared.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordArrray)
                {
                    if (word != "")
                        words.Add(word);
                }

                if (words.Count == 0) continue;
                else sentences.Add(words);
            }

            return sentences;
        }

        private static string ClearSentence(string sentence)
        {
            var sentenceCleared = new StringBuilder();

            foreach (var symbol in sentence)
            {
                if (char.IsLetter(symbol) || (symbol == '\''))
                    sentenceCleared.Append(symbol);
                else sentenceCleared.Append(' ');
            }

            return sentenceCleared.ToString();
        }
    }
}
