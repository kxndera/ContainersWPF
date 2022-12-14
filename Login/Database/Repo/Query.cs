using Login.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repo
{
    internal class Query
    {
        public static bool LoggingValid(string login, string password)
        {
            using (var db = new DbUserContext())
            {
                if (db.Users.FirstOrDefault(x => x.Login == login)?.Password == password)
                {
                    return true;
                }
                else return false;

            }
        }
    }
}

