using System;

namespace AspNetCoreAngular.DTO 
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal Preco { get; set; }
    }
}