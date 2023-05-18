using Demo.Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDemo;

namespace Demo.Entity
{
    public class UserConfig : EntityTypeConfiguration<User, string>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserName).HasMaxLength(50);
            //mock一条数据
            builder.HasData(new User()
            {
                Id = "090213204",
                UserName = "Bruce",
                Birthday = DateTime.Parse("1996-08-24")
            });
        }
    }
}
