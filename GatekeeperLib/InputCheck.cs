using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GatekeeperLib
{
    public static class InputCheck
    {

        public static bool IsPersonNameInCorrectFormat(this string input, int lenght = 50)
        {
            if (input.ContainsOnlyLetters() && input.HasProperLenght(lenght))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// True if string contains only letters (a-žA-Ž). False when empty space, numbers or other chars in string.
        /// </summary>
        public static bool ContainsOnlyLetters(this string input)
        {
            if (Regex.IsMatch(input, @"^[a-žA-Ž]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasProperLenght(this string input, int lenght)
        {
            if(input != null && input.Length > 0 && input.Length <= lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string FirstLetterToCapital(this string input)
        {
            //substring vrátí celý string od x pozice (MujText substring(1) = ujText)
            return Char.ToUpper(input[0]) + input.Substring(1);
        }

        public static bool CheckEntryDate(this DateTime entryDate)
        {
            if(entryDate <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckExitDate(this DateTime exitDate, DateTime entryDate)
        {
            if(exitDate <= DateTime.Now && exitDate > entryDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
