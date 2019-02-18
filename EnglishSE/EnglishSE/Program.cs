using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace EnglishSE
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument word = new XmlDocument();
            word.Load("UnitSE.xml");

            XmlNode Xml_Allword = word.SelectSingleNode("//Unit//U1");

            String temp = Xml_Allword.InnerText;
            string[] s = temp.Split(' ');

            for(int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
            
            Console.ReadKey();
        }
    }
}
