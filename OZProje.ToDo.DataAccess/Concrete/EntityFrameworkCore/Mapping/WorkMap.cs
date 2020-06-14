using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkMap : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(X => X.Id);
            builder.Property(X => X.Id).UseIdentityColumn();
            builder.Property(X => X.Name).HasMaxLength(200);
            builder.Property(X => X.Description).HasColumnType("ntext");
        }
    }
}
