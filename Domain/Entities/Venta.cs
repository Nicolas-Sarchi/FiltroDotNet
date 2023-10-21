using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleadoFk { get; set; }
        public Empleado Empleado { get; set; }
        public int IdClienteFk { get; set; }
        public Cliente Cliente { get; set; }
        public int IdFormaPagoFK { get; set; }
        public FormaPago FormaPago { get; set; }
        public double Total {get;set;}
        public ICollection<DetalleVenta> DetalleVentas { get; set; }

    }
}