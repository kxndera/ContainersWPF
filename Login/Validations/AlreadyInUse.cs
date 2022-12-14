using Login.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    internal class AlreadyInUse
    {
        public static bool AlreadyInDatabase(string login, out string message)
        {
            using (var MyBase = new DbUserContext())
            {
                var query = MyBase.Users.Any(User => User.Login == login);

                if (query)
                {
                    message = "taki użytkownik już jest w bazie";
                    return true;
                }
                else
                {
                    message = "";
                    return false;
                }
            }
        }
    }
}
