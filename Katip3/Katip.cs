using NHunspell;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Katip3
{
    [Serializable(), ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
    public class Katip
    {
        public SpellChecker GetSpellChecker()
        {
            return new SpellChecker();
        }

        public TurkmenGrammar GetGrammar()
        {
            return new TurkmenGrammar();
        }

        public String GetInstallationPath()
        {
            #region Locate Dictionary files
            //Get the deployment directory
            /*
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

            //Location is where the assembly is run from 
            string assemblyLocation = assemblyInfo.Location;

            //CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
            */
            string InstallationLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Katip";

            //dictionaries
            return Path.Combine(InstallationLocation, "tk_TM.aff");
            #endregion
        }
    }

    [Serializable(), ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
    public class SpellChecker
    {
        private Hunspell hunspell;
        private List<String> lstIgnoredWords;
        private List<String> lstUserWords;
        private String userFile;
        private Regex reSplitWords;

        public SpellChecker()
        {
            #region Locate Dictionary files
            /*//Get the deployment directory
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

            //Location is where the assembly is run from 
            string assemblyLocation = assemblyInfo.Location;

            //CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
            */
            string InstallationLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Katip"; 

            //dictionaries
            string affFile = Path.Combine(InstallationLocation, "tk_TM.aff");
            string dictFile = Path.Combine(InstallationLocation, "tk_TM.dic");
            userFile = Path.Combine(InstallationLocation, "tk_TM.usr");
            #endregion

            //strCurrentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string strChars = Convert.ToChar(11).ToString() + Convert.ToChar(12).ToString() +
                Convert.ToChar(14).ToString() + Convert.ToChar(30).ToString() + Convert.ToChar(31).ToString() +
                Convert.ToChar(34).ToString() + Convert.ToChar(160).ToString();

            reSplitWords =  new Regex(@"[ .,:;()×‹›¨¬¯‘’˜±\'\`“”©—«»•·™§¤º|¦#$@%&~…?!^$*<>()\[\]{}\n\r\t" + strChars + "]", RegexOptions.IgnoreCase);

            hunspell = new Hunspell(affFile, dictFile);

            lstIgnoredWords = new List<string>();
            lstUserWords = new List<string>();

            String[] arrUserwords = Utility.ReadLines(userFile);
            foreach(String strWord in arrUserwords)
            {
                lstUserWords.Add(strWord);
                hunspell.Add(strWord);
            }
        }

        public bool SpellCheck(String strWord)
        {
           return hunspell.Spell(strWord);
        }

        public string AddWord(String strWord)
        {
            String strResult = "";
            try
            {
                if (!lstUserWords.Contains(strWord))
                {
                    AddIgnoredWords(strWord);
                    lstUserWords.Add(strWord);
                    strResult += Utility.WriteLines(userFile, lstUserWords.ToArray());
                }
                return strWord + " goşuldy " + userFile + @"\n" + strResult;
            }
            catch(Exception e)
            {
                return strWord + " goşulmady" + userFile;
            }
        }

        public string RemoveWord(String strWord)
        {
            try
            {
                if (lstUserWords.Contains(strWord))
                {
                    lstUserWords.Remove(strWord);
                    Utility.WriteLines(userFile, lstUserWords.ToArray());
                }

                RemoveIgnoredWords(strWord);

                return strWord + " aýryldy" + userFile; ;
            }
            catch (Exception e)
            {
                return strWord + " aýrylmady" + userFile; ;
            }
        }

        public void AddIgnoredWords(String strWord)
        {
            hunspell.Add(strWord);
        }

        public void RemoveIgnoredWords(String strWord)
        {
            hunspell.Remove(strWord);
        }

        public string[] GetSuggestions(string strWord)
        {
            return hunspell.Suggest(strWord).ToArray();
        }

        public void Dispose()
        {
            if (hunspell != null) hunspell.Dispose();
        }

        public string[] GetMisspellings(String strText)
        {
            List<String> lstMisspellings = new List<string>();

            string[] arrWords = reSplitWords.Split(strText);
            foreach(String strWord in arrWords)
            {
                if(!hunspell.Spell(strWord))
                {
                    /*if(strWord.IndexOf("-") > -1)
                    {
                        String[] sParts = strWord.Split('-');
                        if(TurkmenGrammar..Checkstring s1 = strWord.Substring(0, strWord.IndexOf("-"));
                        string s2 = strWord.Substring(strWord.IndexOf())
                    }
                    else
                    {*/
                        lstMisspellings.Add(strWord);
                    //}
                }
            }

            return lstMisspellings.ToArray();
        }
    }
}
