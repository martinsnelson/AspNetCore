using System.Collections.Generic;

namespace AspNetCoreAngular.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set;}
    }
}