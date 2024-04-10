using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dashboard
{
    public class FAQ : BaseEntity<int>, IHasCreatedUser, IHasUpdatedUser, ISoftDelete
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public long? CreatedUserId { get; set; }
        public DateTime? CreatedDate { get ; set ; }
        public long? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
