// See https://aka.ms/new-console-template for more information
using EFCore一对多;
using EFCore一对多.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

using (var ctx = new MyContext())
{
    //var a1 = new Article { Title = "重大发现。。。", Content = "日前，我国科研人员发现。。。" };
    //ctx.Articles.Add(a1);//可以不写 
    //ctx.Comments.Add(new Comment { Content = "哈哈，厉害！", WithArticle = a1 });
    //ctx.Comments.Add(new Comment { Content = "哈哈，点赞！", WithArticle = a1 });
    //ctx.SaveChanges();

    //var a1 = ctx.Articles.Select(x => new { x.Id, x.Title }).FirstOrDefault();
    //Console.WriteLine(a1.Id + "," + a1.Title);

    //var c1 = ctx.Comments.FirstOrDefault();
    //Console.WriteLine($"{c1.Id},{c1.Content},{c1.WithArticleId}");

    //var orgUnitRoot = new OrgUnit { Name = "1" };
    //var orgUnit1 = new OrgUnit { Name = "1.1" };
    //var orgUnit2 = new OrgUnit { Name = "1.2" };
    //var orgUnit3 = new OrgUnit { Name = "1.1.1" };
    //var orgUnit4 = new OrgUnit { Name = "1.1.2" };
    //var orgUnit5 = new OrgUnit { Name = "1.2.1" };
    //var orgUnit6 = new OrgUnit { Name = "1.2.2" };
    //orgUnitRoot.Children.Add(orgUnit1);
    //orgUnitRoot.Children.Add(orgUnit2);
    //orgUnit1.Children.Add(orgUnit3);
    //orgUnit1.Children.Add(orgUnit4);
    //orgUnit2.Children.Add(orgUnit5);
    //orgUnit2.Children.Add(orgUnit6);
    //ctx.OrgUnits.Add(orgUnitRoot);
    //await ctx.SaveChangesAsync();

    //var orgUnitRoot = ctx.OrgUnits.AsNoTracking().Single(x => x.Parent == null);
    //Console.WriteLine(orgUnitRoot.Name);
    //PrintChildren(1, ctx, orgUnitRoot);

    //var aritles = ctx.Articles.AsNoTracking().Where(a => a.WithComments.Any(c => c.Content.Contains("哈哈")));
    /*
     SELECT [t].[Id], [t].[Content], [t].[Title]
      FROM [T_Article] AS [t]
      WHERE EXISTS (
          SELECT 1
          FROM [T_Comment] AS [t0]
          WHERE [t].[Id] = [t0].[WithArticleId] AND ([t0].[Content] LIKE N'%哈哈%'))
     */

    //var aritles = ctx.Comments.AsNoTracking().Where(c => c.Content.Contains("哈哈")).Select(c => c.WithArticle).Distinct();
    //Console.WriteLine(aritles.ToQueryString());
    /*
      SELECT DISTINCT [t0].[Id], [t0].[Content], [t0].[Title]
      FROM [T_Comment] AS [t]
      INNER JOIN [T_Article] AS [t0] ON [t].[WithArticleId] = [t0].[Id]
      WHERE [t].[Content] LIKE N'%哈哈%'
     */
    //foreach (var a in aritles)
    //{
    //    Console.WriteLine(a.Title);
    //}

    //foreach (var a in ctx.Articles)
    //{
    //    Console.WriteLine(a.Title);
    //}
    ////遇到性能瓶颈时可使用下面两种方式之一，否则使用上面的遍历即可。
    //foreach (var a in await ctx.Articles.ToListAsync())
    //{
    //    Console.WriteLine(a.Title);
    //}
    //await foreach (var a in ctx.Articles.AsAsyncEnumerable())
    //{
    //    Console.WriteLine(a.Title);
    //}

    //var articles = ctx.Articles.Where(a => a.WithComments.All(c => c.Content.Contains("哈哈")));
    /*
     * SELECT[t].[Id], [t].[Content], [t].[Title]
     FROM[T_Article] AS[t]
     WHERE NOT EXISTS(
         SELECT 1
         FROM[T_Comment] AS[t0]
         WHERE[t].[Id] = [t0].[WithArticleId] AND NOT([t0].[Content] LIKE N'%哈哈%'))*/
    //var articles = ctx.Articles.Where(a => a.WithComments.Any(c => c.Content.Contains("哈哈")));
    /*
     * SELECT [t].[Id], [t].[Content], [t].[Title]
      FROM [T_Article] AS [t]
      WHERE EXISTS (
          SELECT 1
          FROM [T_Comment] AS [t0]
          WHERE [t].[Id] = [t0].[WithArticleId] AND ([t0].[Content] LIKE N'%哈哈%'))*/
    var articles = ctx.Articles.Where(a => !a.WithComments.Any(c => c.Content.Contains("哈哈")));
    /*
     * SELECT [t].[Id], [t].[Content], [t].[Title]
      FROM [T_Article] AS [t]
      WHERE NOT (EXISTS (
          SELECT 1
          FROM [T_Comment] AS [t0]
          WHERE [t].[Id] = [t0].[WithArticleId] AND ([t0].[Content] LIKE N'%哈哈%')))*/
    foreach (var article in articles)
    {
        Console.WriteLine(article.Title + "," + article.Content);
       
    }
}

static void PrintChildren(int identLevel, MyContext ctx, OrgUnit parent)
{
    var children = ctx.OrgUnits.AsNoTracking().Where(x => x.Parent == parent);//SQL Server数据库（其他数据库可能不支持此特性，建议使用ToList()）连接添加MultipleActiveResultSets=true或者使用.ToList()
    foreach (var child in children)
    {
        Console.WriteLine($"{new string('\t', identLevel)}{child.Name}");
        PrintChildren(identLevel + 1, ctx, child);
    }
}
