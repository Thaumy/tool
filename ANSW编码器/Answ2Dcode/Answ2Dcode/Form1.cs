using System;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Imaging;

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
                Bitmap bp = new Bitmap(openFileDialog1.FileName);
                Color c = new Color();

                for(int y = 0; y < 100; y++)
                {
                    for(int x = 0; x < 100; x++)
                    {
                        c = bp.GetPixel(x, y);
                        switch (c.R)
                        {
                            case 000: textBox1.Text += "0"; break;
                            case 010: textBox1.Text += "1"; break;
                            case 020: textBox1.Text += "2"; break;
                            case 030: textBox1.Text += "3"; break;
                            case 040: textBox1.Text += "4"; break;
                            case 050: textBox1.Text += "5"; break;
                            case 060: textBox1.Text += "6"; break;
                            case 070: textBox1.Text += "7"; break;
                            case 080: textBox1.Text += "8"; break;
                            case 090: textBox1.Text += "9"; break;
                            case 100: textBox1.Text += "a"; break;
                            case 110: textBox1.Text += "b"; break;
                            case 120: textBox1.Text += "c"; break;
                            case 130: textBox1.Text += "d"; break;
                            case 140: textBox1.Text += "e"; break;
                            case 150: textBox1.Text += "f"; break;
                        }
                    }
                }
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
            Bitmap outputBP = (Bitmap)pictureBox1.Image;

            int i = 0;//临时变量
            string str1 = textBox1.Text;
            int len = str1.Length;
            string[,] strArray = new string[100, 100];

            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    strArray[x, y] = "!";//循环记空
                }
            }

            for (int a = 1; a < len; a++)//将字符串分割成数组
            {
                i++;
                str1 = str1.Insert(a + i - 1, " ");
            }

            i = 0;//临时变量
            for (int y = 0; y < 100; y++)//数组赋值到矩阵
            {
                for (int x = 0; x < 100; x++)
                {

                    if (i < str1.Split(' ').Length)
                    {
                        strArray[x, y] = str1.Split(' ')[i];
                    }
                    i++;
                }
            }

            for (int y = 0; y < 100; y++)
            {

                for (int x = 0; x < 100; x++)
                {
                    switch (strArray[x,y])
                    {
                        case "0": outputBP.SetPixel(x, y, Color.FromArgb(000, 0, 0)); break;
                        case "1": outputBP.SetPixel(x, y, Color.FromArgb(010, 0, 0)); break;
                        case "2": outputBP.SetPixel(x, y, Color.FromArgb(020, 0, 0)); break;
                        case "3": outputBP.SetPixel(x, y, Color.FromArgb(030, 0, 0)); break;
                        case "4": outputBP.SetPixel(x, y, Color.FromArgb(040, 0, 0)); break;
                        case "5": outputBP.SetPixel(x, y, Color.FromArgb(050, 0, 0)); break;
                        case "6": outputBP.SetPixel(x, y, Color.FromArgb(060, 0, 0)); break;
                        case "7": outputBP.SetPixel(x, y, Color.FromArgb(070, 0, 0)); break;
                        case "8": outputBP.SetPixel(x, y, Color.FromArgb(080, 0, 0)); break;
                        case "9": outputBP.SetPixel(x, y, Color.FromArgb(090, 0, 0)); break;
                        case "a": outputBP.SetPixel(x, y, Color.FromArgb(100, 0, 0)); break;
                        case "b": outputBP.SetPixel(x, y, Color.FromArgb(110, 0, 0)); break;
                        case "c": outputBP.SetPixel(x, y, Color.FromArgb(120, 0, 0)); break;
                        case "d": outputBP.SetPixel(x, y, Color.FromArgb(130, 0, 0)); break;
                        case "e": outputBP.SetPixel(x, y, Color.FromArgb(140, 0, 0)); break;
                        case "f": outputBP.SetPixel(x, y, Color.FromArgb(150, 0, 0)); break;
                    }
                }
            }
            pictureBox1.Image = outputBP;
            Image img = pictureBox1.Image;
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img.Save(saveFileDialog1.FileName, ImageFormat.Bmp);

            }
        }
    }
}
