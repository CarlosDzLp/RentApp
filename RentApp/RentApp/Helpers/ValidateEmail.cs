using System;
using System.Text.RegularExpressions;

namespace RentApp.Helpers
{
    public static class ValidateEmail
    {
        private static Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
        public static bool IsEmail(string email)
        {
            bool isValid = ValidEmailRegex.IsMatch(email);

            return isValid;
        }
    }
}
