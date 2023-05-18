using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestIsolationLevel
{
    public class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name });
            optionsBuilder.UseSqlServer(@"Data Source=192.168.29.100;Initial Catalog=AbpDemo;Integrated Security=False;User Id=sa;Password=Admin123!;MultipleActiveResultSets=True;TrustServerCertificate=true");
        }
    }
}
