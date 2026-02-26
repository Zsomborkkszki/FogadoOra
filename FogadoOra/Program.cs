using FogadoOra.Controllers;
using FogadoOra.Models;
using System;
using System.Collections.Generic;

namespace FogadoOra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new FogadoOraController().UpdateFogadoOra("2", "Helyszin_Id", "2");
        }
    }
}