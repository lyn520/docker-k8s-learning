using EFCore一对多.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore一对多.ModelConfigs
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Article");
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
        }
    }
}
