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
    public class StudentScoreConfig : IEntityTypeConfiguration<StudentScore>
    {
        public void Configure(EntityTypeBuilder<StudentScore> builder)
        {
            builder.ToTable("T_StudentScore");
        }
    }
}
