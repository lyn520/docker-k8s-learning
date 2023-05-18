namespace TestAlgorithm_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Console.WriteLine(RecursionDemo1(100));
            //Console.WriteLine(RecursionDemo2(30));

            int[] nums = new int[] { 2, 10, 5, 4, 6, 8, 3 };
            BubbleSort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{i} {nums[i]}");
            }
            //TestDemo();
            Console.ReadKey();
        }

        static int RecursionDemo1(int x)
        {
            if (x <= 1)
            {
                return 1;
            }
            else
            {
                return x + RecursionDemo1(x - 1);
            }
        }

        static int RecursionDemo2(int i)
        {
            if (i <= 0)
            {
                Console.WriteLine("Hi");
                return 0;
            }
            else if (i > 0 && i <= 2)
            {
                return 1;
            }
            else
            {
                return RecursionDemo2(i - 1) + RecursionDemo2(i - 2);
            }
        }

        static void SortDemo1(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        Swap(ref nums[i], ref nums[j]);
                    }
                }
            }
        }

        static void SortDemo2(int[] nums)
        {
            int smallest;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[smallest] > nums[j])
                    {
                        smallest = j;
                    }
                }
                Swap(ref nums[i], ref nums[smallest]);
            }
        }

        static void BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)   //由于数组的特点，从0开始，但nums的长度为5，所以需要减1，实际进行了（0~3）4趟循环  
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)  //内层循环的要点是相邻比较。当i=4的时候，就推出循环了  
                {
                    if (nums[j] > nums[j + 1])
                    {
                        Swap(ref nums[j], ref nums[j + 1]);
                    }
                }
            }
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }


        static void TestDemo()
        {
            //表达式：12?56?*123 = 154?4987
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        if ((120560 + b + a * 1000) * 123 == 15404987 + c * 10000)
                        {
                            Console.WriteLine(a);
                            Console.WriteLine(b);
                            Console.WriteLine(c);
                        }
                    }
                }
            }
        }
    }
}