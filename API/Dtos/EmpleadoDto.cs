using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto : BaseDto
    {
        public List<VentaDto> Ventas {get;set;}
    }
}