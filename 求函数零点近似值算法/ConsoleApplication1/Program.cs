using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static double a;
        static double b;
        static double c;

        //计算精度
        static double n;

        //区间
        static double num1;
        static double num2;

        static void Main(string[] args)
        {
            Console.WriteLine("-->请输入a值");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-->请输入b值");
            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-->请输入c值");
            c = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("-->您将要进行的计算为 f(x)= " + a + "x^2 + " + b + "x + " + c + "\n");

            Console.WriteLine("-->请输入零点所在区间");
            Console.Write("从 ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("到 ");
            num2 = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("-->请输入计算精度");
            n = Convert.ToDouble(Console.ReadLine());

            if (f(num1) == 0)
            {
                Console.WriteLine("@--第 1 次计算结果为");
                Console.WriteLine("!--正在计算的区间为 [ " + num1 + " , " + num2 + " ]");
                Console.WriteLine("零点解出，值为 " + num1);
            }
            else if (f(num2) == 0)
            {
                Console.WriteLine("@--第 1 次计算结果为");
                Console.WriteLine("!--正在计算的区间为 [ " + num1 + " , " + num2 + " ]");
                Console.WriteLine("零点解出，值为 " + num2);
            }
            else if (f(num1) * f(num2) < 0)//如果异号
            {
                double a1 = num1;
                double a2 = num2;
                int i=0;
                do
                {
                    i++;
                    double mid = (a1 + a2) / 2;
                    Console.WriteLine("@--第 " + i + " 次计算结果为");

                    if ((f(mid) == 0) & (f(a1) * f(a2) != 0))
                    {
                        Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");
                        Console.WriteLine(" ==零点解出，值为 " + mid);
                    }
                    else if (f(a1) == 0)
                    {
                        Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");
                        Console.WriteLine(" ==零点解出，值为 " + a1);
                    }
                    else if (f(a2) == 0)
                    {
                        Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");
                        Console.WriteLine(" ==零点解出，值为 " + a2);
                    }
                    else if ((f(mid) > 0) & (f(a1) * f(a2) < 0))//缩小区间
                    {
                        if (f(a1) > 0)
                        {
                            Console.WriteLine("!--正在计算的区间为 [ " + a2 + " , " + a1 + " ]");
                            a1 = mid;
                            Console.WriteLine(" --已提取中点值为 " + mid);
                            Console.WriteLine(" --零点所在区间更改为 [ " + a2 + " , " + a1 + " ]");
                            Console.WriteLine(" ==此时函数值域为 [ " + f(a2) + " , " + f(a1) + " ]\n");

                            jingdujiance(a1, a2, n);
                        }
                        else if (f(a1) < 0)
                        {
                            Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");
                            a2 = mid;
                            Console.WriteLine(" --已提取中点值为 " + mid);
                            Console.WriteLine(" --零点所在区间更改为 [ " + a1 + " , " + a2 + " ]");
                            Console.WriteLine(" ==此时函数值域为 [ " + f(a1) + " , " + f(a2) + " ]\n");

                            jingdujiance(a1, a2, n);
                        }

                    }
                    else if ((f(mid) < 0) & (f(a1) * f(a2) < 0))//缩小区间
                    {
                        if (f(a1) > 0)
                        {
                            Console.WriteLine("!--正在计算的区间为 [ " + a2 + " , " + a1 + " ]");
                            a2 = mid;
                            Console.WriteLine(" --已提取中点值为 " + mid);
                            Console.WriteLine(" --零点所在区间更改为 [ " + a2 + " , " + a1 + " ]");
                            Console.WriteLine(" ==此时函数值域为 [ " + f(a2) + " , " + f(a1) + " ]\n");

                            jingdujiance(a1, a2, n);
                        }
                        else if (f(a1) < 0)
                        {
                            Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");
                            a1 = mid;
                            Console.WriteLine(" --已提取中点值为 " + mid);
                            Console.WriteLine(" --零点所在区间更改为 [ " + a1 + " , " + a2+" ]");
                            Console.WriteLine(" ==此时函数值域为 [ " + f(a1) + " , " + f(a2) + " ]\n");

                            jingdujiance(a1, a2, n);
                        }

                    }
                    else
                    {
                        Console.WriteLine("!--正在计算的区间为 [ " + a1 + " , " + a2 + " ]");

                        Console.WriteLine("\n!!!因检测到运算结果为二值同号： f(" + a1 + ") = " + f(a1) + " 和 f(" + a2 + ") = " + f(a2));

                        Console.WriteLine("\n ==函数运算请求被拒绝\n");
                    }

                } while ((jinwei(a1, n) != jinwei(a2, n)) & (f(a1) * f(a2) < 0));//未达到精度再次计算
            }
            else
            {
                Console.WriteLine("!--正在计算的区间为 [ " + num1 + " , " + num2 + " ]");

                Console.WriteLine("\n!!!因检测到运算结果为二值同号： f(a1) = " + f(num1)+" 和 f(a2) = "+ f(num2));

                Console.WriteLine("\n ==函数运算请求被拒绝");
            }

            Console.ReadKey();
        }

        static public double f(double x)
        {
            double result;
            result = a * x * x + b * x + c;
            return result;
        }

        /// <summary>
        /// 进行四舍五入的方法
        /// </summary>
        /// <param name="d">被操作值</param>
        /// <param name="n">被保留到的小数位</param>
        /// <returns></returns>
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
            else if(xiaoshu < 0.5)//小于0.5则退位
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

        /// <summary>
        /// 判断是否达到精确度的方法
        /// </summary>
        /// <param name="a1">被判断值</param>
        /// <param name="a2">被判断值</param>
        /// <param name="n">被保留到的小数位</param>
        static public void jingdujiance(double a1, double a2, double n)
        {
            if (jinwei(a1, n) == jinwei(a2, n))
            {
                Console.WriteLine("已达到计算精度，运算终止");
                Console.WriteLine("\n所得近似零点值为 " + jinwei(a1, n));
            }
        }
    }
}
