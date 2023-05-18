using EFCore一对多.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore一对多
{
    public class MyContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrgUnit> OrgUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDb1;Trusted_Connection=True;MultipleActiveResultSets=true");

            ////简单日志
            //optionsBuilder.LogTo(msg =>
            //{
            //    if (!msg.Contains("CommandExecuting")) return;//只打印执行的sql命令
            //    Console.WriteLine(msg);
            //}, new string[] { "" });
            //optionsBuilder.EnableSensitiveDataLogging();

            ////标准日志
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
