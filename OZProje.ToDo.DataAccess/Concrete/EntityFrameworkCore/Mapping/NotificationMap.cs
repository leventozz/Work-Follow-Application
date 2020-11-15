using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Notifications).HasForeignKey(x => x.AppUserId);
        }
    }
}
