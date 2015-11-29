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
            var add = false;
            List < string > strList= new List<string>();
            List<Word> words = new List<Word>();
            strList = inStr.Split().ToList();
            for (int i = 0; i < strList.Count; i++)
            {
                var strCheck = strList[i];
                add = false;
                foreach (Word wordInst in words)
                {
                    if (wordInst.word == strCheck)
                        wordInst.count++;
                    else
                        add = true;

                }
                if (add || words.Count == 0)
                {
                    words.Add(new Word(strCheck));

                }
            }
            Console.Read();
        }
    }
}
