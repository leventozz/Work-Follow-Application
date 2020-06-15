using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("ntext");

            builder.HasOne(x => x.Priority).WithMany(x => x.Tasks).HasForeignKey(x => x.PriorityId);
        }
    }
}
