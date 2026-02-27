using FogadoOra.Controllers;
using FogadoOra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.View
{
    internal class Megjelenites
    {
        Bejelentkezo currentUser;

        public void GetCurrentUser(Bejelentkezo givenUser)
        {
            currentUser = givenUser;
        }

        public void Regisztracio_Bejelentkezes()
        {
            int current_point = 0;
            bool fut = true;
            string[] menuNevek = { "Bejelentkezés", "Regisztráció", "Kilépés" };
            Action[] menuFunkciok = { Bejelentkezes, Regisztracio, Kilepes };

            while (fut)
            {
                Console.Clear();
                Console.WriteLine("---- főmenü ----");
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
                        menuFunkciok[current_point]();
                        if (current_point == 2) // Kilépés
                            fut = false;
                        Console.WriteLine("Nyomj Enter-t a folytatáshoz...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }

        public void Bejelentkezes()
        {
            Bejelentkezo user = new UserController().Login();
            if (user != null) {
                FoMegjelenites();
            }
        }

        public void Regisztracio()
        {
            Console.WriteLine("Regisztráció");

            new UserController().NewUser();
        }

        public void Kilepes()
        {
          
        }
        












        public void FoMegjelenites()
        {

           
            int current_point = 0;
            bool fut = true;
            Action[] fuggvenyek = { FogadoOraMegjelenites, OraMegjelenitesDatumesOra, OramegjelenitesDatum, KiirAMaiNapra, IdalapjanOra, IdAlapjanFogadoora, JelentkezesTorlese
                    ,Beallitasok };

            string[] fuggvenyNevek =
{
    "Fogadóóra megjelenítés",
    "Óra megjelenites Dátum és óra alapján",
    
    
    "Óra megjelenítése Dátum alapján",
    "Kiiratás a mai napit",
    "Saját fogadóórák",
    "Fogadóórára jelentkezés",
    "Jelentkezés törése",
    "Beállítások"
};


            while (fut)
            {
                Console.WriteLine("----Megjelenítés-----");
                for (int i = 0; i < fuggvenyek.Length; i++)
                {
                    if (i == current_point)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(fuggvenyNevek[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(fuggvenyNevek[i]);
                    }

                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        if (current_point == 0)
                        {
                            current_point = fuggvenyek.Length - 1;
                        }
                        else
                        {
                            current_point--;
                        }
                        break;

                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        if (current_point == fuggvenyek.Length - 1)
                        {
                            current_point = 0;
                        }
                        else
                        {
                            current_point++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        fuggvenyek[current_point]();
                        Console.WriteLine("Enterre tovább...");
                        Console.ReadLine();
                        break;
                    default:
                        break;


                }

                Console.Clear();




            }
        }

        public void IdAlapjanFogadoora()
        {
            FogadoOraMegjelenites();
            Console.WriteLine("Adjon meg egy id-t!");
            int id=int.Parse(Console.ReadLine());
            new JelentkezesController().JelentkezesFogadoOrara(id, currentUser.Id);
        }

        public void Beallitasok()
        {

        }

        public void FogadoOraMegjelenites()
        {
            FogadoOraController controller = new FogadoOraController();
            List<FogadoOraModel> fogadoOrak = controller.GetAllFogadoOra();
            Console.Clear();
            Kiir(fogadoOrak);
        }

        public void OraMegjelenitesDatumesOra()
        {

            Console.WriteLine("Adjon meg egy dátumot (2026-01-01 00:00:00 formátumban): ");
            FogadoOraController controller = new FogadoOraController();
            List<FogadoOraModel> fogadoOrak = controller.GetFogadoOraByDate(DateTime.Parse(Console.ReadLine()));
            Kiir(fogadoOrak);

        }


        public void OramegjelenitesDatum()
        {
            Console.WriteLine("Adjon meg egy dátumot (2026-01-01 formátumban): ");
            FogadoOraController controller = new FogadoOraController();
            List<FogadoOraModel> fogadoOrak = controller.GetFogadoOrakOfDay(Console.ReadLine());
            Kiir(fogadoOrak);
        }

        public void KiirAMaiNapra()
        {
                                                                                                                                                                                                     
            FogadoOraController controller = new FogadoOraController();
            List<FogadoOraModel> fogadoOrak = controller.GetTodayFogadoOras();
            Kiir(fogadoOrak);
            
           
        }

        public void IdalapjanOra()
        {
            Console.WriteLine(currentUser.Id);
            FogadoOraController controller = new FogadoOraController();
            List<FogadoOraModel> fogadoOrak = controller.GetAllFogadoOraOfUser(currentUser.Id);
            Kiir(fogadoOrak);
        }






        public void Kiir(List<FogadoOraModel> fogadoOrak)
        {
            // Fejléc, most az ID-t is tartalmazza
            Console.WriteLine($"| {"ID",-5} | {"Helyszín",-15} | {"Kezdés",-22} | {"Hossz",-10} |");

            // Elválasztó vonal
            Console.WriteLine(new string('-', 70));

            // Adatok kiírása
            foreach (FogadoOraModel ora in fogadoOrak)
            {
                Console.WriteLine($"| {ora.Id,-5} | {ora.Place,-15} | {ora.Start,-22} | {ora.Lenght,-10} |");
            }

            Console.WriteLine(new string('-', 70));
        }



        public void JelentkezesTorlese()
        {
            IdalapjanOra();
            Console.WriteLine("Adjon meg egy id-t!");
            int id = int.Parse(Console.ReadLine());
            new JelentkezesController().JelentkezesTorlese(id, currentUser.Id);
        }
    }
}