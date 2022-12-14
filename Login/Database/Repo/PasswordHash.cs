using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repo
{
    internal class PasswordHash
    { 
        public string HashPassword(string password)
            {
                SHA256 hash = SHA256.Create();

                var passwordBytes = Encoding.Default.GetBytes(password);
                var hashedPassword = hash.ComputeHash(passwordBytes);
                return Convert.ToHexString(hashedPassword);
            }   
    }    
}

