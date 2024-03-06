using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace royhat.Classes
{
    public class Vazifalar
    {
        List<string> royhatlar = new List<string>()
        {
            "Ma'lumotlar",
            "Ma'lumot qo'shish",
            "Ma'lumot o'zgartirish",
            "Ma'lumot o'chirish",
            "exit"
        };

        private void Print1()
        {
            Console.WriteLine("\nBiron bir vazifani bajarmoqchimisiz!🤔\n");
            int son = 1;
            foreach (var royhat in royhatlar)
            {
                if(royhat != "exit")
                {
                    Console.WriteLine(son + "." + royhat);
                    son++;
                }
                else
                {
                    Console.WriteLine("0." + royhat);
                }
                
            }
            
        }

        public string Print()
        {
            Print1();
            Console.Write("Tanlang> ");
            string tanla = Console.ReadLine();
            return tanla;
        }
    }
}
