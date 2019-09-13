using System.Collections.Generic;

namespace AspNetCore.Entities
{
    public class Fornecedor
    {
        public int FornecedorID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public long CNPJ { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set;}
    }
}