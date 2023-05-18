using EFCore入门.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore入门
{
    public class MyContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Cat> Cats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AnimalDb;Trusted_Connection=True");

            ////简单日志
            //optionsBuilder.LogTo(msg =>
            //{
            //    if (!msg.Contains("CommandExecuting")) return;//只打印执行的sql命令
            //    Console.WriteLine(msg);
            //}, new string[] { "" });
            //optionsBuilder.EnableSensitiveDataLogging();

            //标准日志
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
