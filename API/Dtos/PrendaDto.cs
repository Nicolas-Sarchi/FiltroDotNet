using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaDto : BaseIdDto
    {
        public string IdPrenda{get;set;}
        public string Nombre {get;set;}
        public string Estado {get;set;}
    }
}