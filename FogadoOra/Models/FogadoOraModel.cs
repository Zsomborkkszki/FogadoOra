using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogadoOra.Models
{
    internal class FogadoOraModel
    {
        public FogadoOraModel(int place, DateTime start, int lenght)
        {
            this.PlaceId = place;
            this.Start = start;
            this.Lenght = lenght;
        }

        public FogadoOraModel()
        {

        }

        public int Id { get; set; }
        public int PlaceId { get; set; }
        public DateTime Start { get; set; }
        public int Lenght { get; set; }
    }
}
