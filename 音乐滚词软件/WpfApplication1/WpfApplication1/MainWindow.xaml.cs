using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//额外使用的类库
using System.Windows.Threading;
using System.IO;
using System.Threading;

namespace WpfApplication1
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //存储每行歌词数据的结构体
        public struct line
        {
            public long time;//时间轴数据
            public string lyrics;//单行歌词文本
        }

        
        //初始化一个line的非泛型集合类来收录整个歌曲的歌词数据
        static public List<line> lstLine = new List<line>();
        

        //一个用于将时间轴快进或后退的变量
        static public long time_jiaozheng = 0;
        

        //初始化计时器
        DispatcherTimer timer = new DispatcherTimer();
        //初始化表
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();


        //建立一个用于接管歌词进行进度分析的方法的委托
        delegate string[] lrcHandler();
        //实例化该委托，用于后续异步调用
        static lrcHandler lrcHdler = new lrcHandler(getLyricsFromTime);



        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("新建文本文档.txt");

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

            timer.Interval = TimeSpan.FromMilliseconds(1);//初始化

            timer.Tick += TickEvent;//将TickEvent方法绑定在计时器每次执行完之后所触发的事件上

            timer.Start();//开始循环

        }


        //异步分析歌词进行进度
        public static string[] getLyricsFromTime()
        {
            long t = 4000;//前后歌词延迟校正常数

            string[] s = new string[3];//用于存储三行歌词文本

            foreach (line l in lstLine)
            {
                //根据判断计时器是否在某个时间范围内来确定歌词文本
                if ((l.time - 290 <= watch.ElapsedMilliseconds + time_jiaozheng) 
                    && (watch.ElapsedMilliseconds + time_jiaozheng <= l.time + 290))
                {
                    s[1] = l.lyrics;//当前歌词文本赋值
                }
                
                if ((l.time - 290 <= watch.ElapsedMilliseconds + time_jiaozheng + t) 
                    && (watch.ElapsedMilliseconds + time_jiaozheng + t <= l.time + 290))
                {
                    s[2] = l.lyrics;// -1位置歌词文本赋值
                }
                
                if ((l.time - 290 <= watch.ElapsedMilliseconds + time_jiaozheng - t) 
                    && (watch.ElapsedMilliseconds  + time_jiaozheng - t <= l.time + 290))
                {
                    s[0] = l.lyrics;// 1位置歌词文本赋值
                }

            }
            return s;
        }
        private void TickEvent(object sender, EventArgs e)
        {
            //开始异步分析歌词进行进度
            IAsyncResult result = lrcHdler.BeginInvoke(null, null);

            //获取异步结果
            string[] s = lrcHdler.EndInvoke(result);

            if (s[0] != null)
            {
                labelf1.Content = s[0];//主歌词文本调用
            }
            if (s[1] != null)
            {
                MainLabel.Content = s[1];// -1位置歌词文本调用
            }
            if ( s[2]!= null)
            {
                labelz1.Content = s[2];// 1位置歌词文本调用
            }

        }
        
        private void jixv_Click(object sender, RoutedEventArgs e)
        {
            watch.Start();//开始滚动
        }

        private void zanting_Click(object sender, RoutedEventArgs e)
        {
            watch.Stop();//停止滚动
        }

        private void jia_one_Click(object sender, RoutedEventArgs e)
        {
            time_jiaozheng += 500;//时间轴增加0.5秒
        }

        private void jian_one_Click(object sender, RoutedEventArgs e)
        {
            time_jiaozheng -= 500;//时间轴减少0.5秒
        }

    }
}
