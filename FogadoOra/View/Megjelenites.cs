using FogadoOra.Controllers;
using FogadoOra.Models;
using Org.BouncyCastle.Math.EC.Multiplier;
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
        public static bool fut=true;
      

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
           
            Action[] fuggvenyek = { FogadoOraMegjelenites, OraMegjelenitesDatumesOra, OramegjelenitesDatum, KiirAMaiNapra, IdalapjanOra, IdAlapjanFogadoora, FogadooraModositas,  JelentkezesTorlese,  FelhasznaloModositas,FelhasznaloTorlese                   , Kijelentkezes };

            string[] fuggvenyNevek =
{
    "Fogadóóra megjelenítés",
    "Óra megjelenites Dátum és óra alapján",
    
    
    "Óra megjelenítése Dátum alapján",
    "Kiiratás a mai napit",
    "Saját fogadóórák",
    "Fogadóórára jelentkezés",
    "Fogadóóra szekesztése"
,    "Jelentkezés törése",
    "Felhasználó módosítása",
    "Felhasználó törlése",

    "Kijelentkezés"
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
        public void Admin()
        {
            Console.WriteLine("admin felület");
            Console.WriteLine("adja meg a jelszót");
            
                Console.WriteLine("Sikeres admin belépés");

                string[] menupontok = { "Összes helyszín", "Új helyszín", "Helyszín módosítása","Fogadóóra törlése","Fogadóóra létrehozása", "Fogadóóra szerkesztése",  "Helyszín törlése" ,"Kijelentkezés" };

                int current_point = 0;
                bool megy = true;

                while (megy)
                {
                    Console.Clear();
                    Console.WriteLine("---- Helyszín menü ----\n");

                    for (int i = 0; i < menupontok.Length; i++)
                    {
                        if (i == current_point)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(menupontok[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine(menupontok[i]);
                        }
                    }

                    var billentyu = Console.ReadKey(true).Key;

                    switch (billentyu)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            if (current_point == 0)
                                current_point = menupontok.Length - 1;
                            else
                                current_point--;
                            break;

                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            if (current_point == menupontok.Length - 1)
                                current_point = 0;
                            else
                                current_point++;
                            break;

                        case ConsoleKey.LeftArrow:
                            megy = false;
                            break;

                        case ConsoleKey.Enter:
                            Console.Clear();

                            switch (current_point)
                            {
                                case 0: // Összes helyszín
                                    new HelyszinController().AllPlace();
                                    Console.WriteLine("\nEnterrel tovább...");
                                    Console.ReadLine();
                                    break;

                                case 1: // Új helyszín
                                    new HelyszinController().NewPlace();
                                    Console.WriteLine("\nEnterrel tovább...");
                                    Console.ReadLine();
                                    break;

                                case 2: // Helyszín módosítása
                                    new HelyszinController().UpdatePlace();
                                    Console.WriteLine("\nEnterrel tovább...");
                                    Console.ReadLine();
                                    break;

                                case 3:
                                    FogadoOraMegjelenites();

                                    Console.WriteLine("Adjon meg egy id-t");
                                    new FogadoOraController().DeleteFogadoOra(int.Parse(Console.ReadLine()));


                                    break;

                                case 4:
                                new HelyszinController().AllPlace();

                                Console.WriteLine("Adjon meg a helyszín id-t!");
                                    int id=int.Parse(Console.ReadLine());
                                    Console.WriteLine("Adjon meg egy kezdési időpontot");
                                    string start=Console.ReadLine();
                                    Console.WriteLine("Adja meg a hosszát az órának:");
                                    int hossz=int.Parse(Console.ReadLine());    
                                    new FogadoOraController().CreateFogadoOra(id,start,hossz);
                                    break;


                                case 5:
                                    FogadoOraMegjelenites();

                                    Console.WriteLine("Adjon meg egy id-t");
                                    new FogadoOraController().UpdateFogadoOra(Console.ReadLine());
                                    break;

                            case 6:


                                Console.WriteLine("Adjon meg egy id-t");

                                Console.WriteLine("Helyszín tölése");

                                break;

                                case 7:
                                    megy=false;
                                    break;
                            }

                            break;
                    }
                }

            }

        
        

        public void FogadooraModositas()
        {
            IdalapjanOra();
                
            new FogadoOraController().UpdateFogadoOra(Console.ReadLine());
        }





        public void Kiir(List<FogadoOraModel> fogadoOrak)
        {
            

            if (fogadoOrak.Count!=0)
            {
                // Fejléc, most az ID-t is tartalmazza
                Console.WriteLine($"| {"ID",-5} | {"Helyszín",-15} | {"Kezdés",-22} | {"Hossz",-10} |");

                // Elválasztó vonal
                Console.WriteLine(new string('-', 70));
                foreach (FogadoOraModel ora in fogadoOrak)
                {
                    Console.WriteLine($"| {ora.Id,-5} | {ora.Place,-15} | {ora.Start,-22} | {ora.Lenght,-10} |");
                }

                Console.WriteLine(new string('-', 70));
            }

            else
            {
                Console.WriteLine("Nincs fogadóóra");
            }

            // Adatok kiírása
           
        }
      


        public void JelentkezesTorlese()
        {
            IdalapjanOra();
            Console.WriteLine("Adjon meg egy id-t!");
            int id = int.Parse(Console.ReadLine());
            new JelentkezesController().JelentkezesTorlese(id, currentUser.Id);
        }

        public void Kijelentkezes()
        {
            Program.ClearCurrentUser();
            Program.UserCheck();
        }

        public void FelhasznaloTorlese()
        {
            new UserController().DeleteUser(currentUser.Id);
            Console.WriteLine(fut);
            fut = false;
            Kijelentkezes();
        }

         public void FelhasznaloModositas()
        {
            new UserController().UpdateUser();
            
            
            
        }
    }
}