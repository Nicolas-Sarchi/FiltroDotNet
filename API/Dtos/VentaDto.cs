using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaDto : BaseIdDto
    {
        public DateTime Fecha {get;set;}
        public double Total {get;set;}
    }
}