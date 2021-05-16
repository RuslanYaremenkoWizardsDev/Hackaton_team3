using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hackaton_team3
{
    public static class AuthorizationService
    {

        public static bool DoesLoginExist(string email)
        {
            if (email != null)
            {
                bool result = false;
                if (true) /*тут кто-то должен сделать запрос в БД*/
                {
                    result = true;
                }

                return result;
            }

            throw new ArgumentNullException("Email is null.");
        }


        public static bool IsPasswordCorrect(string email, string password)
        {
            if (email != null && password != null)
            {
                bool result = false;
                if (AuthorizationService.DoesLoginExist(email))
                {
                    if (true) //тут кто-то должен проверить поступающий пароль с паролем из БД
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
