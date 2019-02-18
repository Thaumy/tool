using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sreb
{

    public partial class Form1 : Form
    {
        int i = -1;
        bool buf = true;

        Uri uri01 = new Uri("https://www.baidu.com/");
       
        public Form1()
        {
            InitializeComponent();
        }
        /*
        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            webBrowser1.Url = new Uri(((WebBrowser)sender).StatusText);
            e.Cancel = true;
        }
        */
        private void button1_Click(object sender,EventArgs e)
        {
            webBrowser1.Navigate("https://www.baidu.com/");
            
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            //将所有的链接的目标，指向本窗体 
            foreach (HtmlElement archor in this.webBrowser1.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }
            //将所有的FORM的提交目标，指向本窗体 
            foreach (HtmlElement form in this.webBrowser1.Document.Forms)
            {
                form.SetAttribute("target", "_self");
            }
            /*
            if(webBrowser1.Url != uri01)
            {
                i++;
                if(i != 0)
                {
                    tabControl1.TabPages.Add(i.ToString());
                }
            }
            */
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            int height1 = ScreenArea.Height;
            int width1 = ScreenArea.Width;
            tabControl1.Width = this.Width - 22;
            tabControl1.Height = this.Height - 62;
        }
        
        private void New_tabpages(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (buf == true)
            {
                if (webBrowser1.Url != uri01)
                {
                    i++;
                    if (i != 0)
                    {
                        tabControl1.TabPages.Add(i.ToString());
                        buf = false;
                        label1.Text = "flase";

                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buf = true;
            label1.Text = "true";
        }
    }
}
