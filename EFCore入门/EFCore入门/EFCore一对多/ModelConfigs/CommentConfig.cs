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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comment").HasOne(c => c.WithArticle).WithMany(a => a.WithComments).HasForeignKey(c => c.WithArticleId);
            builder.Property(p => p.Content).HasMaxLength(500).IsRequired();
        }
    }
}
