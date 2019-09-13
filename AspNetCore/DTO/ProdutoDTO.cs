using System;

namespace AspNetCore.DTO 
{
    public class ProdutoDTO
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal Preco { get; set; }

        public int CategoriaID { get; set; }
        public string Categoria { get; set; }

        public int FornecedorID { get; set; }
        public string Fornecedor { get; set;}
    }
}