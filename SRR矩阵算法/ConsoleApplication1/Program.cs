using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 8, 4, 5, 5, 5, 3, 7, 9, 2, 9 }; //[HERETEXT]


                        //0  1  2  3  4  5  6  7  8  9 
            int[] opr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[,] buf = new int[10,10];                //^10 N.A.

            int i=-1;
            int[]sar= {1,2,4,6,2,6,5,2,8,0};     //M 0-9    [PASSWORLD]
            int srr=0;


            int f;
            for (f = 0; f < 10; f++)
            {
                foreach (int d in opr)
                {

                    i++;
                    if (i > 10 - sar[f])
                    {
                        srr++;
                    }
                    if (i < 10 - sar[f])
                    {
                        buf[f,i] = opr[i + sar[f]];
                        Console.Write(buf[f,i]);
                    }
                    else
                    {
                        buf[f,i] = opr[srr];
                        Console.Write(buf[f,i]);
                    }
                }
                srr = 0;
                i = -1;
                Console.WriteLine();
            }
            
            int p;
            int arr;
            //int oc=0;

            String[] temp=new string[10];
            for (p=0;p<10;p++)
            {
                for (arr = 0; arr < 10; arr++)
                {
                    if (buf[p,arr] == num[p])
                    {

                        temp[p] = p.ToString() + arr.ToString() +  " ";

                    }
                }
                //oc++;
            }
            p = 0;

            Console.WriteLine();
            for (p = 0; p < 10; p++)
            {
                Console.Write(temp[p]);
            }

            Console.ReadKey();
        }
    }
}