using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dashboard
{
    public class Comment : BaseEntity<int>, IHasCreatedUser, IHasUpdatedUser, ISoftDelete
    {
        public string Text { get; set; }
        public string UserFullName { get; set; }
        public short Value { get; set; }
        public long? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
