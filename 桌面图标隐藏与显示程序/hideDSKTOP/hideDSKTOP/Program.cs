using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;//调用winAPI

namespace hideDSKTOP
{
    class Program
    {

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        static void Main(string[] args)
        {
            //必须存在WorkerW类（有自动更换壁纸之类的系统设定），才能使用以下代码
            IntPtr hwndWorkerW = IntPtr.Zero;
            IntPtr hwndShellDefView = IntPtr.Zero;
            IntPtr hwndDesktop = IntPtr.Zero;

            //因为存在两个WorkerW类，所以要循环取得可用的SysListView32类（桌面）
            while (hwndDesktop == IntPtr.Zero)
            {
                hwndWorkerW = FindWindowEx(IntPtr.Zero, hwndWorkerW, "WorkerW", null);//获得WorkerW类的窗口

                hwndShellDefView = FindWindowEx(hwndWorkerW, IntPtr.Zero, "SHELLDLL_DefView", null);//获得SHELLDLL_DefView类的窗口

                hwndDesktop = FindWindowEx(hwndShellDefView, IntPtr.Zero, "SysListView32", null);//获得SysListView32类的窗口
            }

            //如果获取到了窗口，则不会输出0
            /*
            Console.WriteLine(hwndWorkerW);
            Console.WriteLine(hwndShellDefView);
            Console.WriteLine(hwndDesktop);

            Console.ReadKey();
            */

            if (IsWindowVisible(hwndDesktop) == true)//如果桌面图标可见
            {
                ShowWindow(hwndDesktop, 0);//隐藏图标
            }
            else
            {
                ShowWindow(hwndDesktop, 5);//显示图标
            }


        }
    }
}
