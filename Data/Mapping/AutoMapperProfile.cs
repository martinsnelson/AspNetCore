using AspNetCore.DTO;
using AspNetCore.Entities;
using AutoMapper;

namespace AspNetCore.Data.Mapping
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