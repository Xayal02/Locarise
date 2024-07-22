using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ContactUs
{
    public  class Contact : BaseEntity<int>
    {
        public string RequesterFullName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhone { get; set; }
        public string Message { get; set; }
        public DateTime RequestDate { get; set; }

        

    }
}
