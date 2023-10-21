using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleOrdenDto : BaseIdDto
    {
        public string NombrePrenda {get;set;}
        public string CodPrenda {get;set;}
        public int Cantidad { get; set; } 
        public double ValorTotalPesos {get;set;}
        public double ValorTotalDolares{get;set;}

    }
}