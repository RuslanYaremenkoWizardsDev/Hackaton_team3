using System;
using System.Text.RegularExpressions;

namespace Hackaton_team3
{
    public static class EmailValidation
    {
        private const string _regexEmail = "^[0-9A-Za-z]+(.?[0-9A-Za-z]+){2,29}.?[0-9A-Za-z]+@[a-z]+.[a-z]{2,4}$";
        private static Regex _regex = new Regex(_regexEmail);

        public static bool CheckEmail(string email)
        {
            if (email != null)
            {
                bool result = false;
                if (_regex.IsMatch(email))
                {
                    result = true;
                }

                return result;
            }

            throw new ArgumentNullException("Email is null.");
        }
    }
}
