using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OZProje.ToDo.Entities.Concrete;
using System;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class PriorityMap : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(100);
        }
    }
}
