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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments");

            builder.Property(s => s.Id)
                   .HasColumnName("id");

            builder.Property(s => s.Text)
                   .HasColumnName("text");

            builder.Property(s => s.Value)
                   .HasColumnName("value");

            builder.Property(s => s.UserFullName)
                   .HasColumnName("user_full_name");

            builder.Property(s => s.CreatedUserId)
                  .HasColumnType("smallint")
                  .HasColumnName("created_user_id");


            builder.Property(s => s.CreatedDate)
                  .HasColumnName("created_date");


            builder.Property(s => s.UpdatedUserId)
                  .HasColumnType("smallint")
                  .HasColumnName("updated_user_id");


            builder.Property(s => s.UpdatedDate)
                  .HasColumnName("updated_date");

            builder.Property(s => s.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("0");


        }
    }
}
