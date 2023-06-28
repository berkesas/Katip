using System;
using System.IO;

namespace Katip3
{
    static class Utility
    {
        public static string Right(String str, int Length)
        {
            return str.Substring(str.Length - Length, Length);
        }

        public static string Left(String str, int Length)
        {
            return str.Substring(0, Length);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string WriteLines(String strFilepath, String[] arrWords)
        {
            try
            {
                if (File.Exists(strFilepath))
                {
                    // Create a file to write to.
                    File.WriteAllLines(strFilepath, arrWords);
                    return strFilepath + " ýazyldy";
                }
                {
                    return strFilepath + " tapylmady";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public static String[] ReadLines(String strFilepath)
        {
            String[] arrWords = {};

            if (File.Exists(strFilepath))
            {
                return File.ReadAllLines(strFilepath);
            }
            else
            {
                return arrWords;
            }
        }

    }
}
