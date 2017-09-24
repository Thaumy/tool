using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(jinwei(5.64, 0.1));
            Console.WriteLine(jinwei(5.65, 0.1));
            Console.WriteLine(jinwei(-5.64, 0.1));
            Console.WriteLine(jinwei(-5.65, 0.1));
            Console.ReadKey();
        }
        static public double jinwei(double d, double n)
        {
            int times = Convert.ToInt32(1 / n);//取留整倍数
            double timed = Math.Abs(times * d);//只剩一位小数的绝对值

            int zhengshu = (int)timed;//取整数部分
            double xiaoshu = timed - zhengshu;//取小数部分

            if (xiaoshu >= 0.5)//大于0.5则进位
            {
                if (d < 0)//若d本来是负数
                {
                    return (double)-(zhengshu + 1) / times;
                }
                else//若d本来是非负数
                {
                    return (double)(zhengshu + 1) / times;
                }
            }
            else if (xiaoshu < 0.5)//小于0.5则退位
            {
                if (d < 0)
                {
                    return (double)-zhengshu / times;
                }
                else
                {
                    return (double)zhengshu / times;
                }
            }
            else
            {
                return -1;
            }

        }
    }
}
