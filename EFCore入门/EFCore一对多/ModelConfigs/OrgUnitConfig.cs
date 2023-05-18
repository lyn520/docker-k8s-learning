using EFCore一对多.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore一对多.ModelConfigs
{
    public class OrgUnitConfig : IEntityTypeConfiguration<OrgUnit>
    {
        public void Configure(EntityTypeBuilder<OrgUnit> builder)
        {
            builder.ToTable("T_OrgUnit").HasOne(c => c.Parent).WithMany(a => a.Children);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
