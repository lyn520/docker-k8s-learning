namespace ConsoleAppTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var list2 = new List<int> { 2, 9, 3, 4, 5, 6 };
            //var list3 = Sum(list1, list2);
            //for (int i = 0; i < list3.Count; i++)
            //{
            //    Console.WriteLine(list3[i]);
            //}

            //await NewMethod();

            var task1 = File.ReadAllTextAsync(@"d:\1.txt");
            var task2 = File.ReadAllTextAsync(@"d:\2.txt");
            var strList = await Task.WhenAll(task1, task2);
            Console.WriteLine(strList[0]);
            Console.WriteLine(strList[1]);
        }

        private static async Task NewMethod()
        {
            var source = new CancellationTokenSource();
            source.CancelAfter(5000);
            var cancellationToken = source.Token;
            var mockTask = MockString(10000);
            //try
            //{
            //    var str = await mockTask.WaitAsync(TimeSpan.FromMilliseconds(1000), cancellation);
            //    Console.WriteLine(str);
            //}
            //catch (TimeoutException)
            //{
            //    Console.WriteLine("任务未能在指定的时间内完成！");
            //}
            //catch (TaskCanceledException)
            //{
            //    Console.WriteLine("任务完成前被取消");
            //    //source.Cancel();
            //}
            var str = await mockTask.Timeout2(5000, cancellationToken);
            if (str is not null)
            {
                Console.WriteLine(str);
            }
            else
            {
                Console.WriteLine("任务未能在指定的时间内完成或任务已取消！");
            }
            Console.WriteLine(mockTask.Status);
        }

        static async Task<string> MockString(int milliseconds)
        {
            if (milliseconds > 0)
            {
                await Task.Delay(milliseconds);
            }
            return "This is a mock";
        }

        static List<int> Sum(IList<int> list1, IList<int> list2)
        {
            var result = new List<int>();
            var length = list1.Count > list2.Count ? list1.Count : list2.Count;
            if (length > list1.Count)
            {
                list1 = list1.Reverse().ToList();
                var count = length - list1.Count;
                for (int i = 0; i < count; i++)
                {
                    list1.Add(0);
                }
                list1 = list1.Reverse().ToList();
            }
            if (length > list2.Count)
            {
                list2 = list2.Reverse().ToList();
                var count = length - list2.Count;
                for (int i = 0; i < count; i++)
                {
                    list2.Add(0);
                }
                list2 = list2.Reverse().ToList();
            }
            for (int i = length - 1; i >= 0; i--)
            {
                var num = list1[i] + list2[i];
                if (num > 9)
                {
                    if (i >= 1)
                    {
                        num = num - 10;
                        list1[i - 1]++;
                    }
                }
                result.Add(num);
            }
            result.Reverse();
            return result;
        }

    }
}