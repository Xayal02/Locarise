using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dashboard
{
    public class Statistics : BaseEntity<int>, IHasUpdatedUser
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public long? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
