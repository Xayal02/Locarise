using Domain.Common.Entities;
using Domain.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Login
{
    public class User : BaseEntity<int>,IHasCreationTime,IHasUpdatedTime
    {
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
