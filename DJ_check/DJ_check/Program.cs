using System;
using System.IO;

namespace DJ_check
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入 dng 存放路径（内部照片后缀为 dng ，区分大小写）:");
            var dng_path = Console.ReadLine();
            Console.WriteLine("请输入 jpg 存放路径（内部照片后缀为 jpg ，区分大小写）:");
            var jpg_path = Console.ReadLine();

            DirectoryInfo dng_folder = new DirectoryInfo(dng_path);
            DirectoryInfo jpg_folder = new DirectoryInfo(jpg_path);

            int count = 0;//应删除计数

            //建立存放被删除dng文件的should_be_deleted文件夹
            Directory.CreateDirectory(dng_path + "\\should_be_deleted");

            foreach (FileInfo dng_file in dng_folder.GetFiles("*.dng"))
            {
                var dng_name = dng_file.Name.Substring(0, dng_file.Name.LastIndexOf('.'));

                //如果在jpg文件夹搜索到的指定dng文件个数为0
                if (jpg_folder.GetFiles("*" + dng_name + "*").Length == 0)
                {
                    Console.WriteLine(dng_file.Name);//打印该dng的名字

                    //将dng文件复制到dng文件夹下的should_be_deleted文件夹，并删除该dng文件
                    dng_file.CopyTo(dng_path + "\\should_be_deleted\\" + dng_name + ".dng");
                    File.Delete(dng_path + "\\" + dng_name + ".dng");

                    //计数加一
                    count++;
                }

            }

            Console.WriteLine("统计完成，应删除的 dng 文件个数为：" + count);
            Console.ReadKey();
        }
    }
}
