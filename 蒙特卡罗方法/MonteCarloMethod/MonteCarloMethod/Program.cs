using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MonteCarloMethod
{
    class Program
    {
        public delegate double GetXHandler();
        public delegate double GetYHandler();       
       
        static void Main(string[] args)
        {
            double n = 0;
            double m = 0;
            GetXHandler gxh = new GetXHandler(GetX);//建立获取x轴坐标的委托
            GetXHandler gyh = new GetXHandler(GetY);

            for (int i = 0; i < 1000000000; i++)
            {
                IAsyncResult rslt_x = gxh.BeginInvoke(null, null);//异步调用
                IAsyncResult rslt_y = gxh.BeginInvoke(null, null);
                double x = gxh.EndInvoke(rslt_x);//异步取得x轴坐标
                double y = gxh.EndInvoke(rslt_y);
                ++n;
                if (x * x + y * y <= 1)
                {
                    ++m;
                    Console.WriteLine(4 * m / n + "    运算次：   " + n);
                }
            }
        }
        static double GetX()
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());//取伪随机数

            int i;
            do
            {
                i = ran.Next(-1, 1);
            } while (i == 0);//添加正负号
            return ran.NextDouble() * i;
        }
        static double GetY()
        {
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            int i;
            do
            {
                i = ran.Next(-1, 1);
            } while (i == 0);
            return ran.NextDouble() * i;
        }
    }
}

