using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestIsolationLevel
{
    internal class TestInit
    {
        public static void Test()
        {
            //Dog x = new(1001, "吉吉", 4);
            Dog x1 = new()
            {
                No = 100,
                Name = "吉吉",
                Age = 4
            };
        }
    }
    public class Dog
    {
        public int No { get; init; }
        public string? Name { get; init; }
        public int Age { get; init; }

        //public Dog(int no, string name, int age)
        //{
        //    No = no;
        //    Name = name;
        //    Age = age;
        //}
    }
}
