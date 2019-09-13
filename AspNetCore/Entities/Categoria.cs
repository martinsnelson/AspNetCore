using System.Collections.Generic;

namespace AspNetCore.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set;}
    }
}