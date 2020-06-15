using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Surname).HasMaxLength(100);

            builder.HasMany(x => x.Tasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
