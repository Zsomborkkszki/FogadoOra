using FogadoOra.Models;
using System;
using System.Collections.Generic;

namespace FogadoOra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bejelentkezo bejelentkezo = new Bejelentkezo(0, "", "", "");
            bejelentkezo.Read();
        }
    }
}