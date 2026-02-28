using FogadoOra.Controllers;
using FogadoOra.Models;
using FogadoOra.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace FogadoOra
{
    internal class Program
    {
        static Megjelenites display = new Megjelenites();

        static Bejelentkezo user = null;

        public static void Main(string[] args)
        {
            UserCheck();
        }

        public static void UserCheck()
        {
            while (true)
            {
                display.GetCurrentUser(user);

                if (user == null)
                {
                    Console.Clear();
                    Console.WriteLine("1. Regisztráció\n2. Bejelentkezés\n3. Kilépés");
                    string inp = Console.ReadLine();

                    switch (inp)
                    {
                        case "1":
                            new UserController().NewUser();
                            Console.WriteLine("Enterrel tovább ");
                            Console.ReadLine();
                            break;
                        case "2":
                            user = new UserController().Login();
                            Console.WriteLine("Enterrel tovább ");
                            Console.ReadLine();
                            break;
                        case "3":
                            break;
                    }
                }
                else
                {
                    //Console.WriteLine(user.Id);
                    display.FoMegjelenites();
                }
            }
        }

        public static void ClearCurrentUser()
        {
            user = null;
            display.GetCurrentUser(user);
            Console.WriteLine("user set to null");
        }
    }
}