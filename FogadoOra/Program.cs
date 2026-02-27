using FogadoOra.Controllers;
using FogadoOra.Models;
using FogadoOra.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FogadoOra
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Megjelenites display = new Megjelenites();

            Bejelentkezo user = null;

            while (true)
            {
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

                    display.GetCurrentUser(user);
                    display.FoMegjelenites();
                }
            }
        }
    }
}