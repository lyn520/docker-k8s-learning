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
    public class CatConfig : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            builder.ToTable("T_Cat").Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
