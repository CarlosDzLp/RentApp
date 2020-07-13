using System;
using System.Text.RegularExpressions;

namespace RentApp.Helpers
{
    public static class Validate
    {
        public static bool Email(string email)
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex ValidEmailRegex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);


            bool isValid = ValidEmailRegex.IsMatch(email);

            return isValid;
        }
    }
}
