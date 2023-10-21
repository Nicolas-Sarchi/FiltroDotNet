using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProduccionDto 
    {
        public int IdOrden {get;set;}
         public string IdPrenda{get;set;}
        public string Nombre {get;set;}
        public EstadoDto Estado {get;set;}
    }
}