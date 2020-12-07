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

namespace IDBuilder
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = DateTime.Now;

            //时间获得
            string Year = Convert.ToString(time.Year);
            string Month = Convert.ToString(time.Month);
            string Day = Convert.ToString(time.Day);
            string Hour = Convert.ToString(time.Hour);
            string Minute = Convert.ToString(time.Minute);

            //时间补位
            if (Month.Length != 2) Month = "0" + Month ;
            if (Day.Length != 2) Day = "0" + Day;
            if (Hour.Length != 2) Hour =  "0" + Hour;
            if (Minute.Length != 2) Minute = "0" + Minute;

            string GUID = Guid.NewGuid().ToString("N");

            textBox1.Text = Year + Month + Day + Hour + Minute;
            textBox2.Text = GUID;
            textBox3.Text = textBox1.Text + GUID.Substring(0, 4);
        }
    }
}
