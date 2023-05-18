namespace ConsoleAppTestTimer
{
    internal class Program
    {
        static Timer timer1;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            timer1 = new Timer(TimerGetStatus, null, 0, 2000);
            Console.ReadKey();
        }
        private static void TimerGetStatus(object obj)
        {
            if (DateTime.Now.Second == 59 || DateTime.Now.Second == 00)
            {
                timer1.Change(0, 0);
            }
            Console.WriteLine($"{DateTime.Now}");

        }
    }
}