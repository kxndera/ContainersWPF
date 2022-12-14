using Login.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Database.Model
{
    public class AddingUser
    {
        public static bool AddingToDatabase(string login, string password)
        {

            using (DbUserContext myDbContext = new DbUserContext())
            {
                myDbContext.Users.Add(
                new User()
                {
                    Login = login,
                    Password = password,
                }
                );
                myDbContext.SaveChanges();
                return true;

            }



        }
    }
}
