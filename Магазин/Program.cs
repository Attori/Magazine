using System;
using System.Runtime.InteropServices;

namespace Magasin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           

            while (true)
            {
               // var userChoise = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Приветствуем вас в нашем магазине");
               Console.WriteLine("Для того чтобы  авторизоваться в личном кабинете нажмите [1]");
                var ar = new Menu();
                ar.DoAction();
            }
        }
    }
}