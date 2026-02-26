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
            new FogadoOraController().DeleteFogadoOra("2030-0-01 01:00:00");
        }
    }
}