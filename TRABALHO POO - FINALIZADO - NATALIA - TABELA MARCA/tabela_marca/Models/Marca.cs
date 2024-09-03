using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabela_marca.Models
{
    internal class Marca
    {
        public int Id_marca {  get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public string Localidade { get; set; }
    }
}
