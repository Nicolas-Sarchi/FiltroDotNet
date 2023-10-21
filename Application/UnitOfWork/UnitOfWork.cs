using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;
    public class UnitOfWork : IUnitOfWork

    {
        private readonly AppDbContext context;
        private RoleRepository _roles;
        private UserRepository _Users;
        private CargoRepository _Cargos;
        private ClienteRepository _Clientes;
        private ColorRepository _Colors;
        private DepartamentoRepository _Departamentos;
        private DetalleOrdenRepository _DetalleOrdens;
        private DetalleVentaRepository _DetalleVentas;
        private EmpleadoRepository _Empleados;
        private EmpresaRepository _Empresas;
        private EstadoRepository _Estados;
        private FormaPagoRepository _FormaPagos;
        private GeneroRepository _Generos;
        private InsumoRepository _Insumos;
        private InventarioRepository _Inventarios;
        private MunicipioRepository _Municipios;
        private OrdenRepository _Ordens;
        private PaisRepository _Paises;
        private PrendaRepository _Prendas;
        private ProveedorRepository _Proveedores;
        private TallaRepository _Tallas;
        private TipoEstadoRepository _TipoEstados;
        private TipoPersonaRepository _TipoPersonas;
        private TipoProteccionRepository _TipoProteccions;
        private VentaRepository _Ventas;





        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
        }

        public IUser Users
        {
            get
            {
                if (_Users == null)
                {
                    _Users = new UserRepository(context);
                }
                return _Users;
            }
        }
        public ICargo Cargos
        {
            get
            {
                if (_Cargos == null)
                {
                    _Cargos = new CargoRepository(context);
                }
                return _Cargos;
            }
        }
        public ICliente Clientes
        {
            get
            {
                if (_Clientes == null)
                {
                    _Clientes = new ClienteRepository(context);
                }
                return _Clientes;
            }
        }
        public IColor Colors
        {
            get
            {
                if (_Colors == null)
                {
                    _Colors = new ColorRepository(context);
                }
                return _Colors;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(context);
                }
                return _Departamentos;
            }
        }
        public IDetalleOrden DetalleOrdens
        {
            get
            {
                if (_DetalleOrdens == null)
                {
                    _DetalleOrdens = new DetalleOrdenRepository(context);
                }
                return _DetalleOrdens;
            }
        }
        public IDetalleVenta DetalleVentas
        {
            get
            {
                if (_DetalleVentas == null)
                {
                    _DetalleVentas = new DetalleVentaRepository(context);
                }
                return _DetalleVentas;
            }
        }
        public IEmpleado Empleados
        {
            get
            {
                if (_Empleados == null)
                {
                    _Empleados = new EmpleadoRepository(context);
                }
                return _Empleados;
            }
        }
        public IEmpresa Empresas
        {
            get
            {
                if (_Empresas == null)
                {
                    _Empresas = new EmpresaRepository(context);
                }
                return _Empresas;
            }
        }
        public IEstado Estados
        {
            get
            {
                if (_Estados == null)
                {
                    _Estados = new EstadoRepository(context);
                }
                return _Estados;
            }
        }
        public IFormaPago FormaPagos
        {
            get
            {
                if (_FormaPagos == null)
                {
                    _FormaPagos = new FormaPagoRepository(context);
                }
                return _FormaPagos;
            }
        }
        public IGenero Generos
        {
            get
            {
                if (_Generos == null)
                {
                    _Generos = new GeneroRepository(context);
                }
                return _Generos;
            }
        }
        public IInsumo Insumos
        {
            get
            {
                if (_Insumos == null)
                {
                    _Insumos = new InsumoRepository(context);
                }
                return _Insumos;
            }
        }
        public IInventario Inventarios
        {
            get
            {
                if (_Inventarios == null)
                {
                    _Inventarios = new InventarioRepository(context);
                }
                return _Inventarios;
            }
        }
        public IMunicipio Municipios
        {
            get
            {
                if (_Municipios == null)
                {
                    _Municipios = new MunicipioRepository(context);
                }
                return _Municipios;
            }
        }
        public IOrden Ordens
        {
            get
            {
                if (_Ordens == null)
                {
                    _Ordens = new OrdenRepository(context);
                }
                return _Ordens;
            }
        }public IPais Paises
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new PaisRepository(context);
                }
                return _Paises;
            }
        }public IPrenda Prendas
        {
            get
            {
                if (_Prendas == null)
                {
                    _Prendas = new PrendaRepository(context);
                }
                return _Prendas;
            }
        }public IProveedor Proveedores
        {
            get
            {
                if (_Proveedores == null)
                {
                    _Proveedores = new ProveedorRepository(context);
                }
                return _Proveedores;
            }
        }public ITalla Tallas
        {
            get
            {
                if (_Tallas == null)
                {
                    _Tallas = new TallaRepository(context);
                }
                return _Tallas;
            }
        }public ITipoEstado TipoEstados
        {
            get
            {
                if (_TipoEstados == null)
                {
                    _TipoEstados = new TipoEstadoRepository(context);
                }
                return _TipoEstados;
            }
        }public ITipoPersona TipoPersonas
        {
            get
            {
                if (_TipoPersonas == null)
                {
                    _TipoPersonas = new TipoPersonaRepository(context);
                }
                return _TipoPersonas;
            }
        }
        public ITipoProteccion TipoProteccions
        {
            get
            {
                if (_TipoProteccions == null)
                {
                    _TipoProteccions = new TipoProteccionRepository(context);
                }
                return _TipoProteccions;
            }
        }public IVenta Ventas
        {
            get
            {
                if (_Ventas == null)
                {
                    _Ventas = new VentaRepository(context);
                }
                return _Ventas;
            }
            }
       

        public IRole Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(context);
            }
            return _roles;
        }
    }

        public int Save()
        {
            return context.SaveChanges();
        }
         public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

        public void Dispose()
        {
            context.Dispose();
        }
    }