using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorInsumoDto : BaseDto
    {
        public List<InsumoDto> Insumos {get;set;}
    }
}