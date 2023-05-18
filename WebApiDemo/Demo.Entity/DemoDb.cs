using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class DemoDb : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //循环实体类型，并且通过Entity方法注册类型
            foreach (var entityType in base.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
