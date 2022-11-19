using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _1quickRun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Photoshop.lnk");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Flash.lnk");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Illustrator.lnk");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Audition.lnk");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Premiere Pro.lnk");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\After Effects.lnk");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\Google Chrome.lnk");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\VisualStudio.lnk");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\1quickRun\\BaiduCld.lnk");
        }


        private void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 027)
            {
                System.Environment.Exit(0);//按下ESC键结束程序
            }
        }

        private void Form1_Load(object sender, EventArgs e)//检测2进程名是否存在，存在结束程序
        {

            
            Process[] find = Process.GetProcessesByName("1quickRun");

            if (find.Length>1)
            {
                MessageBox.Show("1quickRun is running! Dont run again!");
                System.Environment.Exit(0);
            }
                        
        }
    }
}
