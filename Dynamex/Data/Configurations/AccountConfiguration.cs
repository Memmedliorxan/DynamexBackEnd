using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Birtday).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            //builder.Property(p => p.PassportFIN).IsRequired().HasColumnType("TEXT");
            //builder.Property(p => p.PassportNumber).IsRequired().HasColumnType("TEXT");
            builder.Property(p => p.Location).IsRequired().HasMaxLength(255);
            builder.Property(p => p.DollarBalance).HasDefaultValue(0);
            builder.Property(p => p.TLBalance).HasDefaultValue(0);

        }
    }
}
