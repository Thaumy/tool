using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace IDBuilder3
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            init();
        }

        private void generate(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void rsa_convert_btn_click(object sender, RoutedEventArgs e)
        {
            if (input.Text != "")
            {
                try
                {
                    rsa_en_de.Text = MathH.RSADecrypt(rsa1.Text, input.Text) ?? MathH.RSAEncrypt(rsa2.Text, input.Text);
                }
                catch { }
            }
        }

        private void md5_convert_btn_click(object sender, RoutedEventArgs e)
        {
            if (input.Text != "")
            {
                try
                {
                    rsa_en_de.Text = MathH.MD5(input.Text);
                }
                catch { }
            }
        }

        private void sha1_convert_btn_click(object sender, RoutedEventArgs e)
        {
            if (input.Text != "")
            {
                try
                {
                    rsa_en_de.Text = MathH.SHA1(input.Text);
                }
                catch { }
            }
        }

        private void init()
        {
            DateTime time = DateTime.Now;

            //时间获得
            string Year = Convert.ToString(time.Year);
            string Month = Convert.ToString(time.Month);
            string Day = Convert.ToString(time.Day);
            string Hour = Convert.ToString(time.Hour);
            string Minute = Convert.ToString(time.Minute);

            //时间补位
            if (Month.Length != 2) Month = "0" + Month;
            if (Day.Length != 2) Day = "0" + Day;
            if (Hour.Length != 2) Hour = "0" + Hour;
            if (Minute.Length != 2) Minute = "0" + Minute;



            string ymdhm = Year + Month + Day + Hour + Minute;

            tb1.Text = Guid.NewGuid().ToString("N");
            tb4.Text = Guid.NewGuid().ToString("D");
            tb2.Text = ymdhm + "-" + Guid.NewGuid().ToString("N").Substring(0, 4);
            tb3.Text = ymdhm;

            var kp = new KeyPair(1024, true);

            rsa1.Text = kp.PrivateKey;
            rsa2.Text = kp.PublicKey;
        }
    }
}
