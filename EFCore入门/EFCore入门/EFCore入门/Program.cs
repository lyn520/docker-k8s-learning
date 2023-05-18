// See https://aka.ms/new-console-template for more information
using EFCore入门;
using EFCore入门.Models;
using Microsoft.EntityFrameworkCore;

using (var ctx = new MyContext())
{
    //var r = new Random();
    //var dog = ctx.Dogs.Add(new Dog { Name = $"Hally{r.Next(100)}" });
    ////var dog = ctx.Dogs.Single(d => d.Id == 1);
    //Console.WriteLine($"dog: id={dog.Entity.Id} ,name={dog.Entity.Name}");

    //var cat = new Cat { Name = $"Haha{r.Next(100)}", Age = 1 };
    //await ctx.Cats.AddAsync(cat);
    ////Console.WriteLine(cat.Id);
    //await ctx.SaveChangesAsync();
    //Console.WriteLine($"dog: id={dog.Entity.Id} ,name={dog.Entity.Name}");
    ////Console.WriteLine(cat.Id);

    //var cat = ctx.Cats.AsNoTracking().FirstOrDefault(c => c.Name.Contains("Ha"));
    //Console.WriteLine(cat.Name);

    IQueryable<Cat> cats = ctx.Cats.AsNoTracking().Where(c => c.Name.Contains("Ha"));
    var sql = cats.ToQueryString();
    Console.WriteLine(sql);
    Console.WriteLine(cats.ToArray()[0].Name);

    //using (var conn = ctx.Database.GetDbConnection())
    //{
    //    conn.Open();
    //    using (var cmd = conn.CreateCommand())
    //    {
    //        cmd.CommandText = "select top 1 name from T_Cat where Name like '%Ha1%'";
    //        var name = cmd.ExecuteScalar() as string;
    //        Console.WriteLine($"Name:{name}");
    //        //cmd.CommandText = "select top 1 Age from T_Cat where Name like '%Ha%'";
    //        cmd.CommandText = "select CAST(1 as int)";
    //        var o = Convert.ToInt32(cmd.ExecuteNonQuery());
    //        Console.WriteLine($"Age:{o}");
    //        //using (var dataReader = cmd.ExecuteReader())
    //        //{
    //        //    if (dataReader.HasRows)
    //        //    {
    //        //        while (dataReader.Read())
    //        //        {
    //        //            Console.WriteLine($"{dataReader[0]},{dataReader["Name"]},{dataReader.GetInt32(2)}");
    //        //        }
    //        //    }
    //        //}
    //    }
    //}
}


