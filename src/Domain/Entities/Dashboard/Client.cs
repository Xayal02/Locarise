using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dashboard
{
    public class Client : BaseEntity<int>, IHasCreatedUser, IHasUpdatedUser
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public long? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
