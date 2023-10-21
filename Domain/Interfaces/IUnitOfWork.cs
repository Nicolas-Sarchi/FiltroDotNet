namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRole Roles { get; }
    IUser Users { get; }
    ICargo Cargos { get; }
    ICliente Clientes { get; }
    IColor Colors { get; }
    IDepartamento Departamentos { get; }
    IDetalleOrden DetalleOrdens { get; }
    IDetalleVenta DetalleVentas { get; }
    IEmpleado Empleados { get; }
    IEmpresa Empresas { get; }
    IEstado Estados { get; }
    IFormaPago FormaPagos { get; }
    IGenero Generos { get; }
    IInsumo Insumos { get; }
    IInventario Inventarios { get; }
    IMunicipio Municipios { get; }
    IOrden Ordens { get; }
    IPais Paises { get; }
    IPrenda Prendas { get; }
    IProveedor Proveedores { get; }
    ITalla Tallas { get; }
    ITipoEstado TipoEstados { get; }
    ITipoPersona TipoPersonas { get; }
    ITipoProteccion TipoProteccions { get; }
    IVenta Ventas {get;}
    Task<int> SaveAsync();
}