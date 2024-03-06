using Microsoft.EntityFrameworkCore;
using royhat.Data;
using royhat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace royhat.Classes
{
    public class DbSelect
    {

        AppDBContext appDB = new AppDBContext(); 
        Show show = new Show();
        public void Select() //bazadan ma'lumot o'qish uchun method
        {
            List<Royhat> royhatList = appDB.royhats.FromSql($"SELECT * FROM dbo.royhats").ToList();
            var soni = royhatList.Count;
            string message = "";
            int number = 1;
            if ( soni == 0 )
            {
                show.view("baza bo'sh");            
            }
            else
            {
                message += "    ism      | familya      | yosh | no'mer           \n";
                message += "    -----------------------------------------\n\n";
                foreach (var royhat1 in royhatList)
                {
                    message += number+ ">|" + royhat1.Name + " | " + royhat1.LastName + " | " + royhat1.Age + " | " + royhat1.phone + "\n";
                    number++;
                }
                show.view(message);
            }
            
            

        }

        public void Add() //bazaga ma'lumot qo'shish uchun Add methodi
        {
            string name = "", lastName = "", phone = "";
            int age = 0;
            Console.WriteLine("orqaga qaytish uchun: 0 ni kiriting");
            Console.Write("ism: ");
            name = Console.ReadLine();
            if (name != "0")
            {
                Console.Write("familiya: ");
                lastName = Console.ReadLine();
                if(lastName != "0")
                {
                    Console.Write("yosh: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    if(age != 0)
                    {
                        Console.Write("no'mer: ");
                        phone = Console.ReadLine();
                    }
                }
            }
            if(name == "0" || lastName == "0" || age == 0 || phone == "0")
            {
                show.view("exit!");
            }
            else
            {
                Add1(name, lastName, age, phone);
            }
            

        }

        public void Update() //bazadami ma'lumotlarni yangilash
        {
            string message = "";
            Select();
            Console.WriteLine("Qaysi foydalanuvchining ma'lumotini o'zgartiramiz!");
            Console.Write("Tanlang> ");
            string tanla = Console.ReadLine();
            int son;
            int.TryParse(tanla, out son);
            son = son - 1;
            List<Royhat> list = appDB.royhats.FromSql($"SELECT * FROM dbo.royhats").ToList();
            var qiymat = list[son];
            message += "ism      | familya      | yosh | no'mer           \n";
            message += "-----------------------------------------\n\n";
            message += qiymat.Name + " | " + qiymat.LastName + " | " + qiymat.Age + " | " + qiymat.phone;
            Console.Clear();
            show.view(message);
            while (true)
            {
                Console.WriteLine("Qaysi ma'lumotini o'zgartiramiz!");
                Console.WriteLine("\n1>ism\n2>familiya\n3>yosh\n4>no'mer\n0>exit");
                Console.Write("\ntanlang> ");
                tanla = Console.ReadLine();
                int.TryParse(tanla, out son);

                if (son == 1)
                {
                    Royhat royhat = appDB.royhats.Single(b => b.Name == qiymat.Name);
                    Console.Write("ism: ");
                    royhat.Name = Console.ReadLine();
                    appDB.SaveChanges();
                    Console.WriteLine("Ism muvoffaqiyatli o'zgartirildi✅");
                }
                else if (son == 2)
                {
                    Royhat royhat = appDB.royhats.Single(b => b.LastName == qiymat.LastName);
                    Console.Write("familiya: ");
                    royhat.LastName = Console.ReadLine();
                    appDB.SaveChanges();
                    Console.WriteLine("Familiya muvoffaqiyatli o'zgartirildi✅");
                }
                else if (son == 3)
                {
                    Royhat royhat = appDB.royhats.Single(b => b.Age == qiymat.Age);
                    Console.Write("yosh: ");
                    royhat.Age = Convert.ToInt32(Console.ReadLine());
                    appDB.SaveChanges();
                    Console.WriteLine("Yosh muvoffaqiyatli o'zgartirildi✅");
                }
                else if (son == 4)
                {
                    Royhat royhat = appDB.royhats.Single(b => b.phone == qiymat.phone);
                    Console.Write("no'mer: ");
                    royhat.phone = Console.ReadLine();
                    appDB.SaveChanges();
                    Console.WriteLine("No'mer muvoffaqiyatli o'zgartirildi✅");
                }
                else if (son == 0)
                {
                    break;
                }
            }
        }

        public void Delete() //bazadan ma'lumotni o'chirish
        {
            Select();
            Console.WriteLine("Qaysi ma'lumotni o'chiramiz!");
            Console.Write("Tanlang> ");
            string tanla = Console.ReadLine();
            int son;
            int.TryParse(tanla, out son);
            son = son - 1;
            List<Royhat> list = appDB.royhats.FromSql($"SELECT * FROM dbo.royhats").ToList();
            var qiymat = list[son];
            Royhat royhat = appDB.royhats.Single(b => b.Id == qiymat.Id);
            appDB.royhats.Remove(royhat);
            appDB.SaveChanges();
            Console.WriteLine("Ma'lumot o'chirildi");

        }

        private void Add1(string name, string lastName, int age, string phone) // bazaga ma'lumot qo'shish uchun private void
        {
            Royhat royhat = new Royhat();
            royhat.Name = name;
            royhat.LastName = lastName;
            royhat.Age = age;
            royhat.phone = phone;

            appDB.royhats.Add(royhat);
            appDB.SaveChanges();
            Console.WriteLine("Muvoffaqiyatli qo'shildi✅");
        }
    }
}
