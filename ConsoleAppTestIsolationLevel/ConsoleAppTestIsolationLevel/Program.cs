// See https://aka.ms/new-console-template for more information
using ConsoleAppTestIsolationLevel;

//Task.Run(() =>
//{
//    var context = new MyContext();
//    using (var tran = context.Database.BeginTransaction())
//    {
//        //Thread.Sleep(1000);
//        Console.WriteLine("线程1进入事务");
//        var person = context.Persons.First(x => x.PersonId == 1);
//        Console.WriteLine($"线程1已加载实体：{person.LastName}");
//        person.LastName = "志成1";
//        context.SaveChanges();
//        Console.WriteLine("线程1已更改实体，但未提交");
//        Thread.Sleep(20000);
//        tran.Commit();
//        Console.WriteLine("线程1已提交");
//    }
//});

//Task.Run(() =>
//{
//    var context = new MyContext();
//    using (var tran = context.Database.BeginTransaction())
//    {
//        //Thread.Sleep(3000);
//        Console.WriteLine("线程2进入事务");
//        var person = context.Persons.First(x => x.PersonId == 1);
//        Console.WriteLine($"线程2已加载实体：{person.LastName}");
//        person.LastName = "志成2";
//        context.SaveChanges();
//        Console.WriteLine("线程2已更改实体，但未提交");
//        tran.Commit();
//        Console.WriteLine("线程2已提交");
//    }
//});

//Task.Run(() =>
//{
//    var context = new MyContext();
//    Console.WriteLine("线程3进入");
//    var person = context.Persons.First(x => x.PersonId == 1);
//    Console.WriteLine($"线程3已加载实体：{person.LastName}");
//    person.LastName = "志成3";
//    context.SaveChanges();
//    Console.WriteLine("线程3已提交");
//});
//TestGroupJoin.Example();
//TestSwitch.Test();
string s = "Assds";
s = null;
Console.WriteLine(s?.ToLower());
Console.ReadKey();