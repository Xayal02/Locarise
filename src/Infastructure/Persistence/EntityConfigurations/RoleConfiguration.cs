using Domain.Entities.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasData(new Role() { Id = 1, Name = "Admin" }, new Role { Id = 2, Name = "Freelancer"}, new Role { Id = 3, Name = "User"});

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(x => x.Name)
                   .HasColumnName("name");

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValueSql("0")
                   .HasColumnName("is_deleted");
        }
    }
}
