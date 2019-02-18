using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//额外使用的类库
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        //存储每行歌词数据的结构体
        struct line
        {
            public long time;//时间轴数据
            public string lyrics;//单行歌词文本
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("新建文本文档.txt");

            //初始化一个line的非泛型集合类来收录整个歌曲的歌词数据
            List<line> lstLine=new List<line>();

            
            string line;//用于存储单行获取到的信息
            while ((line = sr.ReadLine()) != null)
            {
                //分割单行歌词为数组
                string[] lrcLine = line.Split(new char[] { '[', ':', '.', ']' });

                line tempL;

                //时间轴转毫秒
                //lrcLine[1] 为 分钟
                //        2     秒
                //        3     毫秒
                //        4     歌词文本
                tempL.time = Convert.ToInt32(lrcLine[1]) * 60000 + Convert.ToInt32(lrcLine[2]) * 1000 + Convert.ToInt32(lrcLine[3]);

                //对歌词文本赋值
                tempL.lyrics = lrcLine[4];

                lstLine.Add(tempL);
            }

            //输出时间轴和歌词文本
            foreach(line l in lstLine)
            {
                Console.WriteLine(l.time+l.lyrics);
            }

            Console.ReadKey();
        }
    }
}
