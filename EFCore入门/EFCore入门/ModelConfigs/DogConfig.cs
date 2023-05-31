using EFCore入门.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore入门.ModelConfigs
{
    public class DogConfig : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.ToTable("T_Dog").Property(p => p.Name).IsConcurrencyToken().HasMaxLength(20).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
            //builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
