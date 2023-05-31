// See https://aka.ms/new-console-template for more information
using EFCore入门;
using EFCore入门.Models;
using ExpressionTreeToString;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using (var ctx = new MyContext())
{
    //var r = new Random();
    //var dog = ctx.Dogs.Add(new Dog { Name = $"Hally{r.Next(100)}" });
    //Console.WriteLine($"dog: id={dog.Entity.Id} ,name={dog.Entity.Name}");
    //var dog = ctx.Dogs.Single(d => d.Id == 1);
    //Console.WriteLine($"dog: id={dog.Id} ,name={dog.Name}");

    //var cat = new Cat { Name = $"Haha{r.Next(100)}", Age = 1 };
    //await ctx.Cats.AddAsync(cat);
    ////Console.WriteLine(cat.Id);
    //await ctx.SaveChangesAsync();
    //Console.WriteLine($"dog: id={dog.Entity.Id} ,name={dog.Entity.Name}");
    ////Console.WriteLine(cat.Id);

    //var cat = ctx.Cats.AsNoTracking().First(c => c.Name.Contains("Ha"));
    //Console.WriteLine(cat.Name);

    //IQueryable<Cat> cats = ctx.Cats.AsNoTracking().Where(c => c.Name.Contains("Ha"));
    //var sql = cats.ToQueryString();
    //Console.WriteLine(sql);
    //Console.WriteLine(cats.ToArray()[0].Name);

    //FormattableString sql = @$"select top 1 name from T_Cat where Name like '%Ha1%'";
    //ctx.Database.ExecuteSql(sql);
    //ctx.Database.ExecuteSqlInterpolated(sql);

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

    //var yearAmounts = ctx.YearAmounts.Where(x => !new[] { 1991, 1992 }.Contains(x.Year));
    //foreach (var yearAmount in yearAmounts)
    //{
    //    Console.WriteLine(yearAmount.Year + '-' + yearAmount.Month + ":" + yearAmount.Amount);
    //}

    //var sss = ctx.StudentScores.Where(s => !new[] { "张三", "李四" }.Contains(s.Name));
    //foreach (var ss in sss)
    //{
    //    Console.WriteLine(ss.Name + "-" + ss.Subject + ":" + ss.Score);
    //}

    Func<Cat, bool> f1 = c => c.Age > 1 && c.Name.Contains("Ha");
    Expression<Func<Cat,bool>> e1= c => c.Age > 1 && c.Name.Contains("Ha");
    //Console.WriteLine(e1.ToString(RendererNames.ObjectNotation, RendererNames.CSharp));
    /*
    var c = new ParameterExpression {
        Type = typeof(Cat),
        IsByRef = false,
        Name = "c"
    };

    new Expression<Func<Cat, bool>> {
        NodeType = ExpressionType.Lambda,
        Type = typeof(Func<Cat, bool>),
        Parameters = new ReadOnlyCollection<ParameterExpression> {
            c
        },
        Body = new BinaryExpression {
            NodeType = ExpressionType.AndAlso,
            Type = typeof(bool),
            Left = new BinaryExpression {
                NodeType = ExpressionType.GreaterThan,
                Type = typeof(bool),
                Left = new MemberExpression {
                    Type = typeof(int?),
                    Expression = c,
                    Member = typeof(Cat).GetProperty("Age")
                },
                Right = new UnaryExpression {
                    NodeType = ExpressionType.Convert,
                    Type = typeof(int?),
                    Operand = new ConstantExpression {
                        Type = typeof(int),
                        Value = 1
                    }
                }
            },
            Right = new MethodCallExpression {
                Type = typeof(bool),
                Object = new MemberExpression {
                    Type = typeof(string),
                    Expression = c,
                    Member = typeof(Cat).GetProperty("Name")
                },
                Arguments = new ReadOnlyCollection<Expression> {
                    new ConstantExpression {
                        Type = typeof(string),
                        Value = "Ha"
                    }
                },
                Method = typeof(string).GetMethod("Contains", new[] { typeof(string) })
            }
        },
        ReturnType = typeof(bool)
    }
     */

    Console.WriteLine(e1.ToString(RendererNames.FactoryMethods, RendererNames.CSharp));
    /*
     // using static System.Linq.Expressions.Expression

        var c = Parameter(
            typeof(Cat),
            "c"
        );

        Lambda(
            AndAlso(
                GreaterThan(
                    MakeMemberAccess(c,
                        typeof(Cat).GetProperty("Age")
                    ),
                    Convert(
                        Constant(1),
                        typeof(int?)
                    )
                ),
                Call(
                    MakeMemberAccess(c,
                        typeof(Cat).GetProperty("Name")
                    ),
                    typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                    Constant("Ha")
                )
            ),
            c
        )
     */
    ctx.Cats.Where(f1).ToArray();
    ctx.Cats.Where(e1).ToArray();
}




