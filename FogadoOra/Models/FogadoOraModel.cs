using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Models
{
    internal class FogadoOraModel
    {
        public FogadoOraModel(string place, DateTime start, int lenght)
        {
            this.Place = place;
            this.Start = start;
            this.Lenght = lenght;
        }

        public FogadoOraModel()
        {

        }

        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public int Lenght { get; set; }
    }
}
