using Domain.Entities.AboutUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.EntityConfigurations
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("team_members");

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.FullName)
                   .HasColumnName("full_name");

            builder.Property(c => c.ImagePath)
                   .HasColumnName("image_path");

            builder.Property(c => c.Position)
                   .HasColumnName("position");

            builder.Property(c => c.CreatedUserId)
                  .HasColumnType("smallint")
                  .HasColumnName("created_user_id");


            builder.Property(c => c.CreatedDate)
                  .HasColumnName("created_date");


            builder.Property(c => c.UpdatedUserId)
                  .HasColumnType("smallint")
                  .HasColumnName("updated_user_id");


            builder.Property(c => c.UpdatedDate)
                  .HasColumnName("updated_date");

            builder.Property(c => c.IsDeleted)
                  .HasDefaultValueSql("0")
                  .HasColumnName("is_deleted");
               
        }
    }
}
