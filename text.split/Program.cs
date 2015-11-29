using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text.split
{
    class Program
    {
        static void Main(string[] args)
        {
            var inStr = Console.ReadLine();
            var strB = new StringBuilder();
            foreach (char c in inStr){if (!char.IsPunctuation(c)) { strB.Append(c);}}
            inStr = strB.ToString();
            var found = false;
            List < string > strList= new List<string>();
            List<Word> words = new List<Word>();
            strList = inStr.ToLower().Split().ToList();
            for (int i = 0; i < strList.Count; i++)
            {
                var strCheck = strList[i];
                found = false;
                foreach (Word wordInst in words)
                {
                    if (!found)
                    {
                        if (wordInst.word == strCheck)
                        {
                            found = true;
                            wordInst.count++;
                        }
                    }
                }
                if (!found || words.Count == 0)
                {
                    words.Add(new Word(strCheck));
                }
            }
            foreach (Word wo in words)
                Console.WriteLine(@"""{0}"": {1}", wo.word, wo.count);
            Console.Read();
        }
    }
}
