using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;


namespace 桌面图标显示与隐藏程序
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

        public const int SW_SHOW = 5;
        public const int SW_HIDE = 0;

        static void Main(string[] args)
        {
            //初始化
            IntPtr hwndWorkerW = IntPtr.Zero;
            IntPtr hwndShellDefView = IntPtr.Zero;
            IntPtr hwndDesktop = IntPtr.Zero;

            //因为存在的WorkerW类有2个，所以要遍历以取得可用的WorkerW类
            while (hwndDesktop == IntPtr.Zero)//如果获取不到SysListView32类（hwndDesktop），重新循环
            {
                hwndWorkerW = FindWindowEx(IntPtr.Zero, hwndWorkerW, "WorkerW", null);//获得WorkerW类的窗口

                hwndShellDefView = FindWindowEx(hwndWorkerW, IntPtr.Zero, "SHELLDLL_DefView", null);//获得SHELLDLL_DefView类的窗口

                hwndDesktop = FindWindowEx(hwndShellDefView, IntPtr.Zero, "SysListView32", null);//获得SysListView32类的窗口
            }


            //测试是否获取到句柄的代码，如果取到，则不会输出0
            /*  
            Console.WriteLine(hwndWorkerW);
            Console.WriteLine(hwndShellDefView);
            Console.WriteLine(hwndDesktop);

            Console.ReadKey();
            */

            if (IsWindowVisible(hwndDesktop) == true)//如果图标可见
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
