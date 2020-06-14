using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(X => X.Id);
            builder.Property(X => X.Id).UseIdentityColumn();
            builder.Property(X => X.Name).HasMaxLength(100).IsRequired();
            builder.Property(X => X.LastName).HasMaxLength(100).IsRequired(false);
            builder.Property(X => X.Phone).HasMaxLength(10);
            builder.Property(X => X.Email).HasMaxLength(10).IsRequired();

            builder.HasMany(X => X.Works).WithOne(X => X.User).HasForeignKey(X => X.UserId);
        }
    }
}
