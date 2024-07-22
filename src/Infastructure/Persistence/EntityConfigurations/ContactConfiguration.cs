using Domain.Entities.ContactUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.EntityConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.ToTable("contact_us_requests");

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.RequesterFullName)
                   .HasColumnName("requester_full_name");

            builder.Property(c => c.RequesterEmail)
                   .HasColumnName("requester_email");

            builder.Property(c => c.RequesterPhone)
                   .HasColumnName("requester_phone");

            builder.Property(c => c.Message)
                   .HasColumnName("request_message");

            builder.Property(c => c.RequestDate)
                   .HasDefaultValue(DateTime.UtcNow)
                   .HasColumnName("request_date");





        }
    }
}
