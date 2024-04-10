using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string username) :base($"Account with email {username} had already registered")
        {
            
        }
    }
}
