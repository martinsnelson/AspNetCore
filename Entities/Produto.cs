using System;

namespace AspNetCore.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal Preco { get; set; }

        public int CdCategoria { get; set; }
        public virtual Categoria Categoria { get; set;}

        public int CdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set;}

    }
}