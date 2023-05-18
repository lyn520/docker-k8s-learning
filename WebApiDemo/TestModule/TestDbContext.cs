using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule.Models;

namespace TestModule
{
    public class TestDbContext : DbContext
    {
        //private readonly string _connectionString;
        public DbSet<PersonModel> Persons { get; set; }

        //public TestDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
