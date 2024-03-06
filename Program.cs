using Microsoft.EntityFrameworkCore;
using royhat.Classes;
using royhat.Data;
using royhat.Models;

namespace royhat
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDBContext appDBContext = new AppDBContext();
            Vazifalar vazifalar = new Vazifalar();
            Show show = new Show();
            DbSelect dbSelect = new DbSelect();
            bool t = true;

            Console.WriteLine("--Dasturga xush kelibsiz!--[@xayotbek]\n");

            while(t)
            {
                int son;
                int.TryParse(vazifalar.Print(), out son);

                if(son == 0) //exit uchun
                {
                    Console.WriteLine("Xayr sog' bo'ling");
                    t = false;
                }
                else if (son == 1)
                {
                    Console.Clear();
                    dbSelect.Select();
                }
                else if(son == 2)
                {
                    Console.Clear();
                    dbSelect.Add();
                }
                else if(son == 3)
                {
                    Console.Clear();
                    dbSelect.Update();
                }
                else if(son == 4)
                {
                    Console.Clear();
                    dbSelect.Delete();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n——————--——\n[ error! ]\n————————--\n");
                }
            }
        }
    }
}