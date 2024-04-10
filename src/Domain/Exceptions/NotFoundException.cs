using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The item has not been found")
        {

        }
        public NotFoundException(string message) : base(message)
        { 
        
        }
    }
}
