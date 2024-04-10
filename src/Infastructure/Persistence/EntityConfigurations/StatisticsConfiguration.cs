using Domain.Entities.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.EntityConfigurations
{
    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.ToTable("statistics");

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Name)
                   .HasColumnName("name");

            builder.Property(c => c.Value)
                   .HasColumnName("value");

            builder.Property(c => c.UpdatedUserId)
                  .HasColumnName("updated_user_id");


            builder.Property(c => c.UpdatedDate)
                  .HasColumnName("updated_date");
        }
    }
}
