using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenByClientDto
    {
         public string IdCliente { get; set; }
         public string NombreCliente { get; set; }
        
        public string Municipio {get;set;}


        public List<DetalleOrdenDto> DetallesOrden {get;set;}
    }
}