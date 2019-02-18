using System;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Threading;

using StdLib1_17;
using StdLib1_17.StdEct;

namespace Answ2Dcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文件解码按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class_ANSW answ = new Class_ANSW();
                textBox1.Text = answ.DeANSW(openFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 模板指定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bp;
            }
        }
        /// <summary>
        /// 生成二维码按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class_ANSW answ = new Class_ANSW();
                pictureBox1.Image = answ.ToANSW(textBox1.Text, openFileDialog1.FileName);
                Image img = pictureBox1.Image;
                img.Save(saveFileDialog1.FileName);
            }
        }

    }
}
