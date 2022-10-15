using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FolderMakerForGateVideo
{
    public static class Match
    {
        public static string PreprocessText(string v)
        {
            if (v.Contains('-'))
            {
                string substr = v.Substring(0, v.IndexOf('-'));
                if (substr.Length <= 4)
                    v = v.Substring(v.IndexOf('-') + 1);
            }
            StringBuilder sb = new StringBuilder();
            //char[] arr = v.ToLower().ToCharArray();
            char[] arr = v.ToCharArray();
            for (int i = 0; i < v.Length; i++)
            {
                if (char.IsLetter(arr[i]) || arr[i] == ' ')
                    sb.Append(arr[i]);
                else if (char.IsNumber(arr[i]))
                    sb.Append(" " + arr[i] + " ");
                else
                    sb.Append(" ");

            }
            //s = s.Replace(@"_", "-");
            string s = Regex.Replace(sb.ToString().Trim(), @"\s+", " ").ToLower();
            //s = Regex.Replace(s, @"\-+", "-");
            //s = Regex.Replace(s, @"(\- )+", "-");

           
            return s;
        }

        public static string FindBestMatch(string textTomatch, List<string> physicalContentFileListToFindMatch, double expectedPercentageMatch)
        {
            
            float maxMatchedPercent = 0;
            long maxIntersectIndex = -1;
            long temp;
            List<string> textWordsList = PreprocessText(textTomatch).Split(' ').ToList();
            int textWordsCount = textWordsList.Count();
            int fileNameWordsCount = 0;
            for (int i = 0; i < physicalContentFileListToFindMatch.Count; i++)
            {
                List<string> fileNameWordsList = PreprocessText(Path.GetFileNameWithoutExtension(physicalContentFileListToFindMatch[i])).Split(' ').ToList();
                fileNameWordsCount = fileNameWordsList.Count();
                if (fileNameWordsCount > 3 && textWordsCount > 2)
                {
                    if (textWordsCount < fileNameWordsCount)
                    {
                        float percent = (float)(textWordsCount) / fileNameWordsCount * 100;
                        if (percent < 50)
                            continue;
                    }
                    if (fileNameWordsCount < textWordsCount)
                    {
                        float percent = (float)fileNameWordsCount / textWordsCount * 100;
                        if (percent < 50)
                            continue;
                    }
                }
                temp = textWordsList.Intersect(fileNameWordsList).Count();

                float matchedPercent = (float)temp / textWordsCount * 100;
                if (matchedPercent >= expectedPercentageMatch)
                {
                    if (matchedPercent > maxMatchedPercent)
                    {
                        maxMatchedPercent = matchedPercent;
                        maxIntersectIndex = i;
                    }
                    else if (matchedPercent == maxMatchedPercent)//if no of words matched are same
                    {
                        List<string> previouslyMatchedWordsList = PreprocessText(Path.GetFileNameWithoutExtension(physicalContentFileListToFindMatch[(int)maxIntersectIndex])).Split(' ').ToList();
                        if (fileNameWordsCount < previouslyMatchedWordsList.Count())
                        {
                            maxIntersectIndex = i;
                        }
                        //else if(fileNameWordsCount== previouslyMatchedWordsList.Count())
                        //{
                        //    char[] textCharArray = textTomatch.ToCharArray();
                        //    char[] currentMatchCharArray = PreprocessText(listToFindMatch[i]).ToCharArray();
                        //    char[] previousMatchCharArray = PreprocessText(listToFindMatch[(int)maxIntersectIndex]).ToCharArray();
                        //    if(currentMatchCharArray.Count()< previousMatchCharArray.Count())
                        //    {
                        //        maxIntersectIndex = i;
                        //    }
                        //    else if(currentMatchCharArray.Count() == previousMatchCharArray.Count())
                        //    {
                        //        if (textCharArray.Intersect(currentMatchCharArray).Count() > textCharArray.Intersect(previousMatchCharArray).Count())
                        //        {
                        //            maxIntersectIndex = i;
                        //        }
                        //    }
                        //}
                    }
                }
            }
            //MessageBox.Show("Best matched string is " + Environment.NewLine + listToCheck[(int)maxIntersectIndex]);
            if (maxIntersectIndex != -1)
                return physicalContentFileListToFindMatch[(int)maxIntersectIndex];
            else
                return "";
        }


    }
}