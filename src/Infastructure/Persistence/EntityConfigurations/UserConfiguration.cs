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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(u => u.Id)
                   .HasColumnName("id");


            builder.Property(u => u.FullName)
                   .HasColumnName("full_name");

            builder.Property(u => u.Email)
                   .HasColumnName("email");

            builder.Property(u => u.Password)
                   .HasColumnName("password");

            builder.Property(u => u.EmailConfirmed)
                   .HasColumnName("email_confirmed");

            builder.Property(u => u.CreatedDate)
                   .HasColumnName("created_date")
                   .HasColumnType("datetime2");

            builder.Property(u => u.UpdatedDate)
                   .HasColumnName("updated_date")
                   .HasColumnType("datetime2");

            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId);

        }
    }
}
