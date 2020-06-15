using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext");
            builder.HasOne(x => x.Task).WithMany(x => x.Reports).HasForeignKey(x => x.TaskId);
        }
    }
}
