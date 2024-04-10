using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Application.Helpers
{
    public static class TextHasher
    {
        public static string EncryptText(string text)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string hashedText = BCrypt.Net.BCrypt.HashPassword(text, salt);

            return hashedText;

        }

        public static bool Verify(string text, string hashedText) => BCrypt.Net.BCrypt.Verify(text, hashedText);
        

}
}
