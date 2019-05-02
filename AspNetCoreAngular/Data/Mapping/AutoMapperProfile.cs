using AspNetCoreAngular.DTO;
using AspNetCoreAngular.Entities;
using AutoMapper;

namespace AspNetCoreAngular.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
        CreateMap<ProdutoDTO, Produto>();
        CreateMap<CategoriaDTO, Categoria>();
        CreateMap<FornecedorDTO, Fornecedor>();
        CreateMap<LoginDTO, Usuario>();
        CreateMap<RegistrarDTO, Usuario>();
        }
    }
}