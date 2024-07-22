using Domain.Entities.AboutUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persictence.EntityConfigurationc
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Name)
                   .HasColumnName("name");

            builder.Property(c => c.ImagePath)
                   .HasColumnName("image_path");

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
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("0");
        }
    }
}
