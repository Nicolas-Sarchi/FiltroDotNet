using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaGroupDto
    {
        public string TipoProteccion {get;set;}
        public List<PrendaDto> Prendas { get; set; }
    }
}