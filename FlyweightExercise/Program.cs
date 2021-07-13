using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FlyweightExercise
{
    public class Sentence
    {
        private string PlainText;
        private string[] ReturnText;
        private WordToken[] WT;

        public Sentence(string plainText)
        {
            this.PlainText = plainText;
            ReturnText = PlainText.Split(' ');
            WT = new WordToken[ReturnText.Length];
            for (int i = 0; i < WT.Length; i++)
            {
                WT[i] = new WordToken();
            }
        }

        public WordToken this[int index]
        {
            get
            {
                WordToken _wordToken = new WordToken();
                WT[index] = _wordToken;
                return _wordToken;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < ReturnText.Length; i++)
            {
                sb.Append(WT[i].Capitalize.Equals(true)
                    ? $"{ReturnText[i].ToUpper()}"
                    : $"{ReturnText[i].ToLower()}");
                if (i < ReturnText.Length - 1)
                    sb.Append(' ');
            }
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            WriteLine(sentence);
        }
    }
}
