using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchPi
{
    class Program
    {
        public delegate double calPiHandler(int n);

        static void Main(string[] args)
        {

            Console.WriteLine("欢迎来到 BenchPi ！");
            Console.WriteLine("此软件是水瓜社性能基准测试系统的一部分。");
            Console.WriteLine("它根据一个正方形微分为若干单位后落入内切圆的单位数来计算圆周率，以此评估性能。");
            Console.WriteLine();
            Console.WriteLine("线程调用数：8");
            Console.WriteLine("模拟时间设定为：60sec");
            Console.WriteLine();
            Console.WriteLine("评估开始前请关闭除BenchPi在外的所有应用。");
            Console.WriteLine();
            Console.WriteLine("按任意键开始评估性能。");

            Console.ReadKey();



            calPiHandler handler = new calPiHandler(calPi);

            //用BeginInvoke开始异步操作
            IAsyncResult result1 = handler.BeginInvoke(799999, null, null);
            IAsyncResult result2 = handler.BeginInvoke(799998, null, null);
            IAsyncResult result3 = handler.BeginInvoke(799997, null, null);
            IAsyncResult result4 = handler.BeginInvoke(799996, null, null);
            IAsyncResult result5 = handler.BeginInvoke(799995, null, null);
            IAsyncResult result6 = handler.BeginInvoke(799994, null, null);
            IAsyncResult result7 = handler.BeginInvoke(799993, null, null);
            IAsyncResult result8 = handler.BeginInvoke(799992, null, null);

            double part1 = handler.EndInvoke(result1);
            double part2 = handler.EndInvoke(result2);
            double part3 = handler.EndInvoke(result3);
            double part4 = handler.EndInvoke(result4);
            double part5 = handler.EndInvoke(result5);
            double part6 = handler.EndInvoke(result6);
            double part7 = handler.EndInvoke(result7);
            double part8 = handler.EndInvoke(result8);

            double score = (part1 + part2 + part3 + part4 + part5 + part6 + part7 + part8) / 8 / 3.1415926535897;

            Console.WriteLine("性能指数：" + score);
            Console.WriteLine("性能指数越接近 1，则表明CPU性能越高。");
            Console.WriteLine();
            if (score > 0.08)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("您的设备已达到水瓜性能标准！");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("您的设备未达到水瓜性能标准！");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("按任意键退出程序。");
            Console.ReadKey();

        }

        static double calPi(int n)
        {
            DateTime time = DateTime.Now;

            int i = 0;
            double sum = 0;
            double pi = 0;

            while ((DateTime.Now - time).TotalSeconds < 60)
            {
                if (i == n)
                {
                    break;
                }

                i++;

                sum += (int)Math.Sqrt(n * (double)n - i * (double)i);

                pi = (4.0 * sum) / n / n;

                Console.WriteLine(pi);
            }

            return pi;
        }
    }
}
