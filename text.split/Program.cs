﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text.split
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Operations
            var inStr = "";
            var p = Directory.GetCurrentDirectory() + "/input.txt";
            if (File.Exists(p))
                inStr = File.ReadAllText(p);
            else
                inStr = Console.ReadLine();
            inStr.Replace(Environment.NewLine, "");
            var strB = new StringBuilder();
            foreach (char c in inStr){if (!char.IsPunctuation(c) && (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))) { strB.Append(c);}}
            var found = false;
            List < string > strList= new List<string>();
            List<Word> words = new List<Word>();
            strList = strB.ToString().ToLower().Split().Where(c => c!="").ToList();
            float totalP = 0, compPercent = 0, oldPerc = 0;
            for (int i = 0; i < strList.Count; i++)
            {
                var strCheck = strList[i];
                found = false;
                foreach (Word wordInst in words)
                {
                    if (wordInst.word == strCheck && !found)
                    {
                        found = true;
                        wordInst.count++;
                        break;
                    }
                }
                if (!found || words.Count == 0)
                {
                    words.Add(new Word(strCheck));
                }
                compPercent = (float)Math.Round(((float)i / (float)strList.Count) * 100, 0);
                if (oldPerc < compPercent)
                {
                    oldPerc = compPercent;
                    Console.Clear();
                    Console.Write("{0}% of word crunching complete", compPercent);
                }
            }
            #endregion
            #region Write data
            p = Directory.GetCurrentDirectory() + @"\Output.txt";
            if(File.Exists(p))
                File.Delete(p);
            Console.Clear();
            string t = "Generated by text.split on " + DateTime.Today.ToString("d") + Environment.NewLine;
            Console.Write(t);
            File.WriteAllText(p,t);
            int index = 1;
            totalP = 0;
            compPercent = 0;
            oldPerc = 0;
            foreach (Word wo in words.OrderByDescending(o => o.count).ThenBy(s => s.word).ToList())
            {
                float percent = (float)Math.Round(((float)wo.count / (float)strList.Count) * 100,4);
                totalP += percent;
                string txt = String.Format(@"{0}. ""{1}"": {2} {3}. {4}% of the input", index, wo.word, wo.count, (wo.count != 1)?"occurences":"occurence", percent) + Environment.NewLine;
                File.AppendAllText(p, txt);
                index++;
                compPercent = (float)Math.Round(((float)index / (float)words.Count) * 100, 0);
                if (oldPerc < compPercent)
                {
                    oldPerc = compPercent;
                    Console.Clear();
                    Console.Write("{0}{1}{2}% of data writing complete{1}", t, Environment.NewLine, compPercent);
                }
            }
            t = string.Format("Total words: {0} Unique words: {1} Percent unique words: {2}%{3}% total percentage (may be above or below 100% because of rounding)", strList.Count, words.Count,(((float)words.Count/(float)strList.Count)*100),Environment.NewLine + totalP);
            Console.Write("{0}Open {1} for full results",t + Environment.NewLine,p);
            File.AppendAllText(p,t);
            #endregion
            Console.ReadLine();
        }
    }
}
