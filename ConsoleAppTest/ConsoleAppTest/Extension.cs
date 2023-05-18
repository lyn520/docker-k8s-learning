using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public static class Extension
    {
        public static async Task<T?> Timeout<T>(this Task<T> task, int milliseconds)
        {
            var now = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < now)
            {
                if (task.IsCompleted)
                {
                    return await task;
                }

                //await Task.Delay(100);
            }

            return default;
        }
        public static async Task<T?> Timeout2<T>(this Task<T> task, int milliseconds)
        {
            var timeoutTask = Task.Delay(milliseconds);
            var finishedTask = await Task.WhenAny(task, timeoutTask);
            if (finishedTask == timeoutTask)
            {
                //表示请求超时
                return default;
            }
            return await task;

            //if (!task.IsCompleted && timeoutTask.IsCompleted)
            //{
            //    //表示请求超时
            //    return default;
            //}
            //return await task;
        }

        public static async Task<T?> Timeout2<T>(this Task<T> task, int milliseconds, CancellationToken cancellationToken)
        {

            //if (cancellationToken.IsCancellationRequested)
            //{
            //    //表示请求取消
            //    await Console.Out.WriteLineAsync("请求取消");
            //    return default;
            //}

            var timeoutTask = Task.Delay(milliseconds, cancellationToken);
            await Console.Out.WriteLineAsync("开始执行任务......");
            var finishedTask = await Task.WhenAny(task, timeoutTask);
            if (finishedTask == timeoutTask)
            {
                //表示请求超时
                await Console.Out.WriteLineAsync("请求超时或请求取消");
                return default;
            }

            return await task;

            //if (!task.IsCompleted && timeoutTask.IsCompleted)
            //{
            //    //表示请求超时
            //    return default;
            //}
            //return await task;
        }

    }
}
