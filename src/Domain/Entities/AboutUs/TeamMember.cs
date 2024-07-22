using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AboutUs
{
    public class TeamMember : BaseEntity<int>,IHasCreatedUser , IHasUpdatedUser, ISoftDelete
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ImagePath { get; set; }
        public long? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate {  get; set; }
        public bool IsDeleted { get; set; }

    }
}
