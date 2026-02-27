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
        public void FoMegjelenites()
        {

            bool bejelentkezve = false;
            int current_point = 0;
            bool fut = true;
            Action[] fuggvenyek = { FogadoOraMegjelenites, OraMegjelenitesDatumesOra, OramegjelenitesDatum, KiirAMaiNapra, Beallitasok };

            string[] fuggvenyNevek =
{
    "Fogadóóra megjelenítés",
    "Óra megjelenites Dátum és óra alapján",
    
    
    "Óra megjelenítése Dátum alapján",
    "Kiiratás a mai napit",
    
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



        public void Kiir(List<FogadoOraModel> fogadoOrak)
        {
            Console.WriteLine($"| {"Helyszín ID",-15} | {"Kezdés",-22} | {"Hossz",-10} |");

            // 2. Elválasztó vonal rajzolása
            Console.WriteLine(new string('-', 56));

            // 3. Adatok kiírása soronként
            foreach (FogadoOraModel ora in fogadoOrak)
            {
                Console.WriteLine($"| {ora.Place,-15} | {ora.Start,-22} | {ora.Lenght,-10} |");
            }
            Console.WriteLine(new string('-', 56));
        }




        
    }
}