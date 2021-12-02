using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core.Entities
{
    public partial class Platillo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public decimal Peso { get; set; }
        public decimal Calorias { get; set; }
        public decimal Precio { get; set; }
        public int Tipo { get; set; }
    }
}
