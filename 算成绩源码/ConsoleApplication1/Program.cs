using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            Xstu zhangsan = new Xstu("张三", "满族",97,87);

            Console.WriteLine(Average(zhangsan.math, zhangsan.office));

            Console.ReadKey();
        }

        static public double Average(int num1,int num2)
        {
            return (num1 + num2) / 2;
        }
        
    }
    //学生类
    public class stu
    {
        public stu(string name, string nation)
        {
            
        }

        public string name;

        public string nation;
    }
    //大学生类
    public class Xstu :stu
        {
        public Xstu(string name, string nation, int math, int office):base(name,nation)
        {
            base.name = name;
            base.nation = nation;

            this.math = math;
            this.office = office;
        }

        public int math;
        public int office;
    }
}
