using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Login
{
    public class Role : BaseEntity<int>, ISoftDelete
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set ; }
        public List<User> Users { get; set; }
    }
}
