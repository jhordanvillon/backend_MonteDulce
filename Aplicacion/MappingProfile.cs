using Aplicacion.Boletas;
using Aplicacion.Categorias;
using AutoMapper;
using Dominio;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Categoria,CategoriaDto>()
            .ForMember(x => x.Productos, y => y.MapFrom(z => z.ProductoLista));
            CreateMap<Producto,ProductoDto>();
            CreateMap<Boleta,BoletaDto>()
            .ForMember(x => x.Items, y => y.MapFrom( z=> z.ListaItems));
            CreateMap<ItemBoleta,ItemBoletaDto>();
        }
    }
}