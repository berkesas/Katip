using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Katip3
{
    [Serializable(), ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
    public class TurkmenGrammar
    {
        #region data
        char[] TurkmenVowels = new char[] { 'a', 'o', 'y', 'u', 'ä', 'ö', 'i', 'ü' };
        char[] TurkmenInceVowels = new char[] { 'ä', 'ö', 'i', 'ü' };
        char[] TurkmenKptc = new char[] { 'k', 'p', 't', 'ç' };
        char[] TurkmenGbdj = new char[] { 'g', 'b', 'd', 'j' };
        char[] TurkmenZlnrssh = new char[] { 'z', 'l', 'n', 'r', 's', 'ş' };

        char[] TurkmenLiason = new char[] { 'a', 'e', 'y', 'i' };
        char[] TurkmenLiasonTransform = new char[] { 'a', 'ä', 'a', 'ä' };
        char[] TurkmenLiasonTransform2 = new char[] { 'a', 'e', 'a', 'e' };

        char[] TurkmenDodaklanyan = new char[] { 'o', 'u', 'ö', 'ü' };
        char[] TurkmenDodaklanmayan = new char[] { 'a', 'e', 'y', 'i', 'ä' };

        string vowelsTurkmen = "aeyiouäöü";
        string vowelsYogynTurkmen = "aouy";
        string vowelsInceTurkmen = "äeiöü";
        string vowelsDodaklanyanTurkmen = "ouöü";
        string vowelsDodaklanmayanTurkmen = "aeyiä";
        string vowelsLiasonTurkmen = "aeyi";
        string vowelsTransformLiasonTurkmen = "aäaä";
        string vowelsTransformLiasonTurkmen2 = "aeae";
        string kptcTurkmen = "kptç";
        string gbdjTurkmen = "gbdj";
        string zlnrsshTurkmen = "zlnrsş";

        string[] arrDigits = new string[] {
        "nol", "bir", "iki", "üç", "dört", "bäş", "alty",
        "ýedi", "sekiz", "dokuz", "on", "ýigrimi", "otuz", "kyrk", "elli", "altmyş", "ýetmiş", "segsen", "togsan",
        "ýüz", "müň", "million", "milliard", "trillion", "katrillion", "kwintillion", "sekstillion", "septillion",
        "oktillion", "nonillion", "desillion", "undesillion", "duodesillion", "tredesillion", "quattuordesillion" };

        string[] arrEndings = new string[] {
        "njy", "nji", "nji", "nji", "nji", "nji", "njy",
        "nji", "nji", "njy", "njy", "nji", "njy", "njy", "nji", "njy", "nji", "nji", "njy", "nji", "nji", "njy",
        "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy", "njy" };

        string[] arrEndings2 = new string[] {
        "y", "i", "si", "i", "i", "i", "sy", "si", "i", "y", "y", "si", "y", "y", "si",
        "y", "i", "i", "y", "i", "i", "y", "y", "y", "y", "y", "y", "y", "y", "y", "y", "y", "y", "y", "y" };

        string[] arrNumberDigits = new string[] {
        "", "müň", "million", "milliard", "trillion", "katrillion", "kwintillion", "sekstillion", "septillion",
        "oktillion", "nonillion", "desillion", "undesillion", "duodesillion", "tredesillion", "quattuordesillion" };

        string[] arrNumberNames = new string[]
        {
            "", "", "ýüz", "", "", "ýüz", "", "", "ýüz", "", "", "ýüz", "", "", "ýüz", ""
        };

        string[] arrPartialNumbers = new string[]
        {
            "", "ondan", "ýüzden", "müňden", "on müňden", "ýüz müňden", "milliondan", "on milliondan",
            "ýüz milliondan", "milliarddan", "on milliarddan", "ýüz milliarddan", "trilliondan",
            "on trilliondan", "ýüz trilliondan", "katrilliondan"
        };

        string[][] arrNumbers = new string[][] {
            new string[] { "nol", "bir", "iki", "üç", "dört", "bäş", "alty", "ýedi", "sekiz", "dokuz" },
            new string[] { "", "on", "ýigrimi", "otuz", "kyrk", "elli", "altmyş", "ýetmiş", "segsen", "togsan" }
        };

        string[] arrMonthNames = new string[] { "ýanwar", "fewral", "mart", "aprel", "maý", "iýun", "iýul",
        "awgust", "sentýabr", "oktýabr", "noýabr", "dekabr" };

        string[] arrDayNames = new string[]
        {
            "ýekşenbe", "duşenbe", "sişenbe", "çarşenbe", "penşenbe", "anna", "şenbe"
        };

        string[] arrTypes = new string[] {
        "söz", "at", "san", "has at", "sypat", "işlik", "hal", "ümlük", "pred.", "çalyşma", "baglaýjy", "", "", ""
        };

        string[] arrLatChars = new string[]
        {
            "A", "a", "B", "b", "Ç", "ç", "D", "d", "E", "e", "Ä", "ä", "F", "f", "G", "g", "H", "h", "I", "i",
            "J", "j", "Ž", "ž", "K", "k", "L", "l", "M", "m", "N", "n", "Ň", "ň", "O", "o", "Ö", "ö", "P", "p",
            "R", "r", "S", "s", "Ş", "ş", "T", "t", "U", "u", "Ü", "ü", "W", "w", "Y", "y", "Ý", "ý", "Z", "z",
            "S", "s", "Ş", "ş", "", "", "", "", "E", "e"
        };

        string strLatChars = "AaBbÇçDdEeÄäFfGgHhIiJjŽžKkLlMmNnŇňOoÖöPpRrSsŞşTtUuÜüWwYyÝýZzSsŞşEe";
        string strTurkmenAlphanumeric = "AaBbÇçDdEeÄäFfGgHhIiJjŽžKkLlMmNnŇňOoÖöPpRrSsŞşTtUuÜüWwYyÝýZzSsŞşEe0123456789";

        string[] arrLowerCaseLatin = new string[]
        {
            "a", "b", "ç", "d", "ä", "f", "g", "h", "i", "j", "ž", "k", "l", "m", "n", "ň", "o", "ö", "p", "r",
            "s", "ş", "t", "u", "ü", "w", "y", "ý", "z", "s", "ş", "e"
        };

        string strLowerCaseLatin = "abçdäfghijžklmnňoöprsştuüwyýzsşe";

        string[] arrCyrChars = new string[]
        {
            "А", "а", "Б", "б", "Ч", "ч", "Д", "д", "Е", "е", "Ә", "ә", "Ф", "ф", "Г", "г", "Х", "х", "И", "и",
            "Җ", "җ", "Ж", "ж", "К", "к", "Л", "л", "М", "м", "Н", "н", "Ң", "ң", "О", "о", "Ө", "ө", "П", "п",
            "Р", "р", "С", "с", "Ш", "ш", "Т", "т", "У", "у", "Ү", "ү", "В", "в", "Ы", "ы", "Й", "й", "З", "з",
            "Ц", "ц", "Щ", "щ", "Ъ", "ъ", "Ь", "ь", "Э", "э"

        };

        //string strCyrChars = "АаБбЧчДдЕеӘәФфГгХхИиҖҗЖжКкЛлМмНнҢңОоӨөПпРрСсШшТтУуҮүВвЫыЙйЗзЦцЩщЪъЬьЭэ";

        string[] arrLowerCaseCyrillic = new string[]
        {
            "а", "б", "ч", "д", "ә", "ф", "г", "х", "и", "җ", "ж", "к", "л", "м", "н", "ң", "о", "ө", "п", "р",
            "с", "ш", "т", "у", "ү", "в", "ы", "й", "з", "ц", "щ", "ъ", "ь", "э", "е", "ю", "я", "ё"
        };

        string strLowerCaseCyrillic = "абчдәфгхиҗжклмнңоөпрсштуүвыйзцщъьэеюяё";

        string[] arrVowelsCyrillic = new string[] {
            "а", "ә", "и", "о", "ө", "у", "ү", "ы", "э", "е", "ю", "я", "ё"
        };

        string strVowelsCyrillic = "аәиоөуүыэеюяё";

        string[] arrTwoLetterVowelsCyrillic = new string[]
        {
            "Ю", "ю", "Я", "я", "Ё", "ё", "Е", "е"
        };

        //string strTwoLetterVowelsCyrillic = "ЮюЯяЁёЕе";
        string strCyrChars = "АаБбЧчДдЕеӘәФфГгХхИиҖҗЖжКкЛлМмНнҢңОоӨөПпРрСсШшТтУуҮүВвЫыЙйЗзЦцЩщЪъЬьЭэЮюЯяЁёЕе";

        string[] arrTwoLetterVowelsLatin = new string[]
        {
               "Ýu", "ýu", "Ýa", "ýa", "Ýo", "ýo", "Ýe", "ýe"
        };

        string[] arrTwoLetterVowelsAllCapsLatin = new string[]
        {
            "ÝU", "ýu", "ÝA", "ýa", "ÝO", "ýo", "ÝE", "ýe"
        };

        string strAllVowelsLowerCase = "аәиоөуүыэеюяёaoyuäöiü";
        string strAllVowels = "аәиоөуүыэеюяёaoyuäöiüАӘИОӨУҮЫЭЕЮЯЁAOYUÄÖIÜ";

        string strAllLowerCase = "абчдәфгхиҗжклмнңоөпрсштуүвыйзцщъьэеюяёabçdäfghijžklmnňoöprsştuüwyýzsşe";

        string strAllUpperCase = "АБЧДӘФГХИҖЖКЛМНҢОӨПРСШТУҮВЫЙЗЦЩЪЬЭЕЮЯЁABÇDÄFGHIJŽKLMNŇOÖPRSŞTUÜWYÝZSŞE";

        string constYylyn = "ýylyň";
        string constAyynyn = "aýynyň";
        string constTenne = "teňňe";

        string strYi = "yi";
        Regex reAlphanumeric = new Regex("[^AaBbÇçDdEeÄäFfGgHhIiJjŽžKkLlMmNnŇňOoÖöPpRrSsŞşTtUuÜüWwYyÝýZzSsŞşEe0123456789]", RegexOptions.IgnoreCase);
        Regex reRemoveLeadingZeros = new Regex("^0*", RegexOptions.IgnoreCase);
        Regex reRemoveTrailingZeros = new Regex("0+$", RegexOptions.IgnoreCase);
        Regex reTriplets = new Regex(".{1,3}", RegexOptions.IgnoreCase);
        #endregion data

        public string GetFirstVowel(String strWord)
        {
            Char strFirstVowel = new char();

            foreach (Char strLetter in strWord)
            {
                if (Array.IndexOf(TurkmenVowels, strLetter) > -1)
                {
                    strFirstVowel = strLetter;
                    break;
                }
            }
            return strFirstVowel.ToString();
        }

        public string GetLastVowel(String strWord)
        {
            Char strLastVowel = new char();

            for (int i = strWord.Length - 1; i > -1; i--)
            {
                Char strLetter = strWord[i];
                if (Array.IndexOf(TurkmenVowels, strLetter) > -1)
                {
                    strLastVowel = strLetter;
                    break;
                }
            }
            return strLastVowel.ToString();
        }

        public bool IsVowel(String strLetter)
        {
            return (Array.IndexOf(TurkmenVowels, strLetter) > -1);
        }

        public bool IsInce(String strLetter)
        {
            return (Array.IndexOf(TurkmenInceVowels, strLetter) > -1);
        }

        public bool IsConsonant(String strLetter)
        {
            return (Array.IndexOf(TurkmenVowels, strLetter) < 0);
        }

        public int IsLiason(String strLetter)
        {
            return vowelsLiasonTurkmen.IndexOf(strLetter);
        }

        public string Liason(String strWord, int lngPosition)
        {
            return strWord + vowelsTransformLiasonTurkmen2.Substring(lngPosition, 1);
        }

        public int IsGbdj(String strChar)
        {
            return gbdjTurkmen.IndexOf(strChar);
        }

        public int IsKptc(String strChar)
        {
            return kptcTurkmen.IndexOf(Utility.Right(strChar, 1));
        }

        public string Kptc(String strWord, int lngPosition)
        {
            if (strWord.Length > 1)
            {
                return Utility.Left(strWord, strWord.Length - 1) + kptcTurkmen.Substring(lngPosition, 1);
            }
            else
            {
                return "";
            }
        }

        public string Gbdj(String strWord, int lngPosition)
        {
            if (strWord.Length > 1)
            {
                return Utility.Left(strWord, strWord.Length - 1) + gbdjTurkmen.Substring(lngPosition, 1);
            }
            else
            {
                return "";
            }
        }

        public int IsZlnrssh(String strChar)
        {
            return zlnrsshTurkmen.IndexOf(strChar);
        }

        public string Zlnrssh(String strWord, String strEnding)
        {
            String strFallenVowel;
            if (strWord.Length > 2)
            {
                switch (GetLastVowel(strWord))
                {
                    case "a":
                        strFallenVowel = "y";
                        break;
                    case "e":
                        strFallenVowel = "i";
                        break;
                    case "y":
                        strFallenVowel = "y";
                        break;
                    case "i":
                        strFallenVowel = "i";
                        break;
                    case "o":
                        strFallenVowel = "u";
                        break;
                    case "u":
                        strFallenVowel = "u";
                        break;
                    case "ö":
                        strFallenVowel = "ü";
                        break;
                    case "ü":
                        strFallenVowel = "ü";
                        break;
                    default:
                        strFallenVowel = Utility.Left(strEnding, 1);
                        break;
                }
                return Utility.Left(strWord, strWord.Length - 1) + strFallenVowel + Utility.Right(strWord, 1);
            }
            else
            {
                return "";
            }
        }

        public int IsDodak(String strChar)
        {
            return vowelsDodaklanyanTurkmen.IndexOf(strChar);
        }

        public string Dodak(String strWord, int lngPosition)
        {
            if (strWord.Length > 1)
            {
                return Utility.Left(strWord, strWord.Length - 1) + strYi.Substring(lngPosition, 1);
            }
            else
            {
                return "";
            }
        }

        public int IsGole(String strChar)
        {
            return "ä".IndexOf(strChar);
        }

        public string Gole(String strWord)
        {
            if (strWord.Length > 1)
            {
                return Utility.Left(strWord, strWord.Length - 1) + "e";
            }
            else
            {
                return "";
            }
        }

        public string Gole2(String strWord)
        {
            if (strWord.Length > 1)
            {
                return Utility.Left(strWord, strWord.Length - 1) + "i";
            }
            else
            {
                return "";
            }
        }

        public bool CheckOrdinalNumber(String strNumber, String strEnding)
        {
            //int intNumber;
            //String strLastDigitText;
            String strCorrectNumber = "";
            //String[] strNumberTextArray;

            if (IsNumeric(strNumber) && (String.Compare(strEnding, "njy") == 0 || String.Compare(strEnding, "nji") == 0))
            {
                strCorrectNumber = AddEndingOrdinal(strNumber, false);
            }

            if (String.Compare(strCorrectNumber, strNumber + "-" + strEnding) == 0)
            {
                return true;
            }
            else if (IsNumeric(strNumber) && IsNumeric(strEnding))
            {
                return true;
            }

            return false;

        }

        public bool IsNumeric(String strWord)
        {
            int n;
            return int.TryParse(strWord, out n);
        }

        public string NumberToText(String strNumberIn, String strFormat = null, String uppercase = null, String whole_money = null, String coin_money = null)
        {
            String strResult = "";
            String strNumber = strNumberIn;
            strNumber = strNumber.Replace(".", ",");
            String strNumberWhole = "";
            String strNumberPart = "";

            if (strNumber.IndexOf(",") > 0)
            {
                if (strNumber.IndexOf(",") == strNumber.LastIndexOf(","))
                {
                    strNumberWhole = strNumber.Substring(0, strNumber.IndexOf(","));
                    strNumberPart = strNumber.Substring(strNumberWhole.Length + 1, strNumber.Length - strNumberWhole.Length - 1);
                }
                else
                {
                    strResult = "Misformed number";
                }
            }
            else
            {
                strNumberWhole = strNumber;
            }

            //Remove leading zeros from the whole number 00521 -> 521
            strNumberWhole = reRemoveLeadingZeros.Replace(strNumberWhole, "");

            //if(strFormat!="money")
            //{
            //Remove trailing zeros from the partial number 0,1200 -> 0,12
            strNumberPart = reRemoveTrailingZeros.Replace(strNumberPart, "");
            //}

            String strWholeText = GetNumberText(strNumberWhole);
            String strPartialText = GetNumberText(strNumberPart, true);

            String strInterval = "";

            if (strNumberPart.Length > 0)
            {
                strInterval = "bitin " + arrPartialNumbers[strNumberPart.Length];
            }

            if (strPartialText.Length > 0)
            {
                strResult += strWholeText + strInterval + " " + strPartialText;
            }
            else
            {
                strResult += strWholeText;
            }

            strResult = Regex.Replace(strResult, "\\s+", " ");

            return strResult.Trim();
        }

        public string GetNumberText(String strNumberWhole, Boolean IsPartial = false)
        {
            String strWholeText = "";
            //String strWholeText2 = "";

            List<String> lstUnits = new List<string>();

            if (strNumberWhole != "0" && strNumberWhole.Length > 0)
            {
                MatchCollection matches1 = reTriplets.Matches(Utility.Reverse(strNumberWhole));

                foreach (Match match in matches1)
                {
                    lstUnits.Add(match.Value);
                }

                String strTextValues1 = "";
                String strTextValues2 = "";

                String strDigit;
                String strDigitAmount;
                String strDigits;
                int a = 0;
                foreach (String strNumber2 in lstUnits)
                {
                    strDigits = "";
                    MatchCollection matches2 = Regex.Matches(strNumber2, ".{1,1}", RegexOptions.IgnoreCase);
                    int z = 0;
                    foreach (Match match in matches2)
                    {
                        strDigit = match.Value;
                        if (z == 2)
                        {
                            strDigitAmount = arrNumbers[0][System.Int32.Parse(strDigit)];
                        }
                        else
                        {
                            strDigitAmount = arrNumbers[z][System.Int32.Parse(strDigit)];
                        }
                        if (strDigitAmount == "nol")
                        {

                        }
                        else if (arrNumberNames[z] == "")
                        {
                            strDigits = " " + strDigitAmount + strDigits + " ";
                        }
                        else
                        {
                            strDigits = " " + strDigitAmount + " " + arrNumberNames[z] + strDigits + " ";
                        }
                        z++;
                    }
                    if (System.Int32.Parse(strNumber2) != 0)
                    {
                        strTextValues2 = strDigits + arrNumberDigits[a] + " " + strTextValues2;
                        strTextValues1 = strNumber2 + " " + strDigits + arrNumberDigits[a] + "\n" + strTextValues1;
                    }
                    a++;
                }
                strWholeText = strTextValues2;
                //strWholeText2 = strTextValues1;
            }
            else
            {
                if (!IsPartial) strWholeText = "nol";
            }
            return strWholeText;
        }



        public string AddEndingOrdinal(String strNumber, Boolean ToText = false, Boolean Possessive = false)
        {
            String strResult = "";
            String strEnding = "";
            String strNumberText = NumberToText(strNumber);
            String[] arrNumbers = strNumberText.Split(' ');
            string strLastNumberWord = arrNumbers[arrNumbers.Length - 1];
            int u = 0;
            foreach (String str in arrDigits)
            {
                if (strLastNumberWord.Equals(arrDigits[u]))
                {
                    if (Possessive)
                    {
                        strEnding = arrEndings2[u];
                    }
                    else
                    {
                        strEnding = arrEndings[u];
                    }
                    break;
                }
                u++;
            }

            if (IsInce(GetLastVowel(strLastNumberWord)))
            {
                strEnding = strEnding.Replace("y", "i");
            }

            if (ToText)
            {
                strResult = strLastNumberWord + strEnding;
            }
            else
            {
                strResult = strNumber + "-" + strEnding;
            }

            return strResult;
        }

        public string AddEnding(String str, String san = null, String yonkeme = null, String dusum = null, String haysy = null)
        {
            String strUltimateVowel = "";
            String strPenultimateVowel = "";

            String strVowels = "aeouyiäöü";
            String strEnding = str;

            Regex re = new Regex("[" + strVowels + "]", RegexOptions.IgnoreCase);
            MatchCollection matches = re.Matches(Utility.Reverse(str));
            if (matches.Count > 1)
            {
                if (matches[0].Value != null) { strUltimateVowel = matches[0].Value; }
                if (matches[1].Value != null) { strPenultimateVowel = matches[1].Value; }
            }
            else
            {
                if (matches[0].Value != null) { strUltimateVowel = matches[0].Value; }
            }

            if ("aouy".IndexOf(strUltimateVowel) > -1)
            {
                switch (yonkeme)
                {
                    case "men":
                        strEnding += "ym";
                        break;
                    case "sen":
                        strEnding += "yň";
                        break;
                    case "ol":
                        strEnding += "y";
                        break;
                    default:
                        break;
                }

                switch (dusum)
                {
                    case "eyelik":
                        strEnding += "yň";
                        break;
                    case "yonelis":
                        strEnding += "a";
                        break;
                    case "yenis":
                        strEnding += "y";
                        break;
                    case "wagtorun":
                        if (strVowels.IndexOf(Utility.Right(strEnding, 1)) > 1)
                        {
                            strEnding += "nda";
                        }
                        else
                        {
                            strEnding += "da";
                        }
                        break;
                    case "cykys":
                        strEnding += "dan";
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (yonkeme)
                {
                    case "men":
                        strEnding += "im";
                        break;
                    case "sen":
                        strEnding += "iň";
                        break;
                    case "ol":
                        strEnding += "i";
                        break;
                    default:
                        break;
                }

                switch (dusum)
                {
                    case "eyelik":
                        strEnding += "iň";
                        break;
                    case "yonelis":
                        strEnding += "e";
                        break;
                    case "yenis":
                        strEnding += "i";
                        break;
                    case "wagtorun":
                        if (strVowels.IndexOf(Utility.Right(strEnding, 1)) > 1)
                        {
                            strEnding += "nde";
                        }
                        else
                        {
                            strEnding += "de";
                        }
                        break;
                    case "cykys":
                        strEnding += "den";
                        break;

                    default:
                        break;
                }
            }

            return strEnding;
        }

        public string CleanWord(String strString)
        {
            return reAlphanumeric.Replace(strString, "");
        }

        public MatchCollection GetTirkesh(String strText)
        {
            Regex re = new Regex("([" + strTurkmenAlphanumeric + "]*)([-])([" + strTurkmenAlphanumeric + "]*)", RegexOptions.IgnoreCase);
            return re.Matches(strText);
        }

    }

}
