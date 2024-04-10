﻿using Domain.Entities.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.EntityConfigurations
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.ToTable("faqs");

            builder.Property(s => s.Id)
                   .HasColumnName("id");

            builder.Property(s => s.Tittle)
                   .HasColumnName("tittle");

            builder.Property(s => s.Description)
                   .HasColumnName("description");

            builder.Property(s => s.CreatedUserId)
                  .HasColumnName("created_user_id");


            builder.Property(s => s.CreatedDate)
                  .HasColumnName("created_date");


            builder.Property(s => s.UpdatedUserId)
                  .HasColumnName("updated_user_id");


            builder.Property(s => s.UpdatedDate)
                  .HasColumnName("updated_date");

            builder.Property(s => s.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValueSql("0");
        }
    }
}
