using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public static class Helper
    {
        public static bool CheckNameOrSurname(this string text)
        {
            if (text.Length >= 3 && char.IsUpper(text[0]) && !text.Contains(" "))
                return true;
            else
                return false;
        }

        public static bool CheckClassroomName(this string text)
        {
            if (text.Length == 5 && char.IsUpper(text[0]) && char.IsUpper(text[1]) && char.IsDigit(text[2]) && char.IsDigit(text[3]) && char.IsDigit(text[4]))
                return true;
            else
                return false;
        }
    }
}
