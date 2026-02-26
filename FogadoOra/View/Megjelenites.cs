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
            Action[] fuggvenyek = { FogadoOraMegjelenites, OraModositas, OraTorles, UserMegjelenites, UserModositas, UserTorles, Beallitasok };

            string[] fuggvenyNevek =
{
    "Fogadóóra megjelenítés",
    "Óra módosítás",
    "Óra törlés",
    "Felhasználó megjelenítés",
    "Felhasználó módosítás",
    "Felhasználó törlés",
    "Beállítások"
};


            while (fut)
            {
                Console.WriteLine("----Megjelenítés-----");
                for (int i = 0; i < fuggvenyek.Length; i++)
                {
                    if (i == current_point)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
                    default:
                        break;


                }

                Console.Clear();




            }
        }


        public void MegjelenitOra(List<FogadoOraModel> orak)
        {
            Console.WriteLine("Fogadó órák");
            foreach (FogadoOraModel ora in orak)
            {
                Console.WriteLine(ora.Start);
                Console.WriteLine(ora.Lenght);

            }
        }

        public void Beallitasok()
        {

        }

        public void FogadoOraMegjelenites()
        {

        }

        public void UserMegjelenites()
        {

        }


        public void UserModositas()
        {

        }

        public void UserTorles()
        {

        }


        public void OraTorles()
        {

        }


        public void OraModositas()
        {

        }
    }
}