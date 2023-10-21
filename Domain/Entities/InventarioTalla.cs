using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventarioTalla
    {
        public int IdInventarioFK { get; set; }
        public Inventario Inventario { get; set; }
        public int IdTallaFk { get; set; }
        public Talla Talla { get; set; }
        public int Cantidad {get;set;}
    }
}