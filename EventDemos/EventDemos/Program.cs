namespace EventDemos
{
    public delegate void MyDelegate(string message);

    public class MyClass
    {
        public event MyDelegate MyEvent;

        public void RaiseEvent(string message)
        {
            MyEvent(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.MyEvent += new MyDelegate(Method1);
            obj.MyEvent += new MyDelegate(Method2);
            obj.RaiseEvent("Hello, world!");
            Console.ReadKey();
        }

        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message);
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }
    }
}