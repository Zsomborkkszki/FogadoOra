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
                    int current_point = 0;
                    bool megy = true;

                    string[] menuNevek = { "Regisztráció", "Bejelentkezés","Admin", "Kilépés" };

                    while (megy)
                    {
                        Console.Clear();
                        
                        Console.WriteLine("---- Főmenü ----");

                        for (int i = 0; i < menuNevek.Length; i++)
                        {
                            if (i == current_point)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(menuNevek[i]);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine(menuNevek[i]);
                            }
                        }

                        var billentyu = Console.ReadKey(true).Key;

                        switch (billentyu)
                        {
                            case ConsoleKey.UpArrow:
                            case ConsoleKey.W:
                                if (current_point == 0)
                                    current_point = menuNevek.Length - 1;
                                else
                                    current_point--;
                                break;

                            case ConsoleKey.DownArrow:
                            case ConsoleKey.S:
                                if (current_point == menuNevek.Length - 1)
                                    current_point = 0;
                                else
                                    current_point++;
                                break;

                            case ConsoleKey.Enter:
                                Console.Clear();

                                switch (current_point)
                                {
                                    case 0: // Regisztráció
                                        new UserController().NewUser();
                                        Console.WriteLine("Enterrel tovább ");
                                        Console.ReadLine();
                                        break;

                                    case 1: // Bejelentkezés
                                        user = new UserController().Login();

                                        if (user != null)
                                        {
                                            megy = false;
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sikertelen bejelentkezés!");
                                            Console.WriteLine("Enterrel tovább ");
                                            Console.ReadLine();
                                        }
                                        break;

                                    case 2:
                                        new Megjelenites().Admin();
                                        
                                        break;

                                    case 3: // Kilépés
                                        megy = false;
                                        break;
                                }

                                break;
                        }
                    }
                }
                else if(user.Name == "admin")
                {
                    display.Admin();
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