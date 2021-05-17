using System;

namespace Hackaton_team3
{
    public static class AuthorizationService
    {
        public static bool DoesLoginExist(string email)
        {
            Core _core = Core.GetCore();
            if (email != null)
            {
                bool result = false;
                if (_core.EmailExistsInDB(email)) 
                {
                    result = true;
                }

                return result;
            }

            throw new ArgumentNullException("Email is null.");
        }

        public static bool IsPasswordCorrect(string email, string password)
        {
            Core _core = Core.GetCore();
            if (email != null && password != null)
            {
                bool result = false;
                if (AuthorizationService.DoesLoginExist(email))
                {
                    if (_core.PairPasswordEmail(email,password)) //тут кто-то должен проверить поступающий пароль с паролем из БД
                    {
                        result = true;
                    }
                }

                return result;
            }
            else if (password != null)
            {
                throw new ArgumentNullException("Password is null.");
            }
            else
            {
                throw new ArgumentNullException("Email is null.");
            }
        }
    }
}
