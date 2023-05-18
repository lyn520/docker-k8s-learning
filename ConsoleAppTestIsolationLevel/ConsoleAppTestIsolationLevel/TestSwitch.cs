using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestIsolationLevel
{
    internal class TestSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Test()
        {
            var 考试成绩 = 99m;
            switch (考试成绩)
            {
                case 0:
                    Console.WriteLine("缺考？");
                    break;
                case > 0 and <= 30:
                    Console.WriteLine("太烂了");
                    break;
                case > 30 and < 60:
                    Console.WriteLine("还是不行");
                    break;
                case >= 60 and < 80:
                    Console.WriteLine("还得努力");
                    break;
                case >= 80 and < 90:
                    Console.WriteLine("秀儿，真优秀");
                    break;
                case >= 90 and <= 100:
                    Console.WriteLine("不错，奇迹");
                    break;
            }

            Order od = new Order
            {
                ID = 11,
                Company = "大嘴狗贸易有限公司",
                ContactName = "陈大爷",
                Qty = 425.12f,
                UP = 1000.55M,
                Date = new(2020, 10, 27)
            };

            switch (od)
            {
                case { Qty: > 1000f, Company: not null }:
                    Console.WriteLine("发财了，发财了");
                    break;
                case { Qty: > 500f }:
                    Console.WriteLine("好家伙，年度大订单");
                    break;
                case { Qty: > 100f }:
                    Console.WriteLine("订单量不错");
                    break;
            }

            /**如果 switch... 语句在判断之后需要返回一个值，还可以把它变成表达式来用。
            这时候你得注意：
            1）switch 现在是表达式，不是语句块，所以最后大括号右边的分号不能少；
            2）因为 switch 成了表达式，就不能用 case 子句了，所以直接用具体的内容来匹配；
            3）最后返回“未知”的那个下划线（_），也就是所谓的“弃婴”，哦不，是“弃元”，就是虽然赋了值但不需要使用的变量，可以直接丢掉。这里就相当于 switch 语句块中的 default 子句，当前面所有条件都不能匹配时，就返回“未知”。
            */
            string message = od switch
            {
                { Qty: > 1000f } => "发财了",
                { Qty: > 500f } => "年度大订单",
                { Qty: > 100f } => "订单量不错",
                _ => "未知"
            };

            Console.WriteLine(message);
        }
    }

    internal class Order
    {
        public int ID { get; set; }
        public string? Company { get; set; }
        public string? ContactName { get; set; }
        public float Qty { get; set; }
        public decimal UP { get; set; }
        public DateTime Date { get; set; }
    }
}
