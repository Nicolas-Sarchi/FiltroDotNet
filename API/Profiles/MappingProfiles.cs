using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
       CreateMap<User , UserDto>().ReverseMap();
       CreateMap<Cargo , CargoDto>().ReverseMap();
       CreateMap<Cliente , ClienteDto>().ReverseMap();
       CreateMap<Color , ColorDto>().ReverseMap();
       CreateMap<Departamento , DepartamentoDto>().ReverseMap();
       CreateMap<DetalleOrden , DetalleOrdenDto>().ReverseMap();
       CreateMap<DetalleOrden , DetalleOrdenDto>().
       ForMember(d => d.NombrePrenda, o => o. MapFrom(s => s.Prenda.Nombre))
       .ForMember(d => d.CodPrenda,  o=> o.MapFrom(s => s.Prenda.IdPrenda))
       .ForMember(d => d.ValorTotalDolares,  o=> o.MapFrom(s => s.Prenda.ValorUnitUsd))
       .ForMember(d => d.ValorTotalPesos,  o=> o.MapFrom(s => s.Prenda.ValorUnitCop))
       .ForMember(d => d.Cantidad, o => o.MapFrom(s => s.CantidadProducir));

        CreateMap<Orden , OrdenByClientDto>().
       ForMember(d => d.NombreCliente, o => o. MapFrom(s => s.Cliente.Nombre)).
       ForMember(d => d.IdCliente, o => o. MapFrom(s => s.Cliente.IdCliente))
       .ForMember(d => d.Municipio,  o=> o.MapFrom(s => s.Cliente.Municipio.Nombre));

       CreateMap<DetalleVenta , DetalleVentaDto>().ReverseMap();
       CreateMap<Empleado , EmpleadoDto>().ReverseMap();
       CreateMap<Empresa , EmpresaDto>().ReverseMap();
       CreateMap<Estado , EstadoDto>().ReverseMap();
       CreateMap<FormaPago , FormaPagoDto>().ReverseMap();
       CreateMap<Genero , GeneroDto>().ReverseMap();
       CreateMap<Insumo , InsumoDto>().ReverseMap();
       CreateMap<Inventario , InventarioDto>().ReverseMap();
       CreateMap<Municipio , MunicipioDto>().ReverseMap();
       CreateMap<Orden , OrdenDto>().ReverseMap();
       CreateMap<Pais , PaisDto>().ReverseMap();
       CreateMap<Prenda , PrendaDto>().ReverseMap();
       CreateMap<Prenda , PrendaDto>().ForMember(d => d.Estado, o => o.MapFrom(s => s.Estado.Descripcion));

       CreateMap<Proveedor , ProveedorDto>().ReverseMap();
       CreateMap<Proveedor , ProveedorInsumoDto>().ReverseMap();

       CreateMap<Talla , TallaDto>().ReverseMap();
       CreateMap<TipoEstado , TipoEstadoDto>().ReverseMap();
       CreateMap<TipoProteccion , TipoProteccionDto>().ReverseMap();
       CreateMap<TipoPersona , TipoPersonaDto>().ReverseMap();
       CreateMap<Venta , VentaDto>().ReverseMap();

       CreateMap<IGrouping<string , Prenda> , PrendaGroupDto>()
       .ForMember(d => d.TipoProteccion, o=> o.MapFrom(s => s.Key))
       .ForMember(d => d.Prendas, o=> o.MapFrom(s => s));

       
       


    }
}