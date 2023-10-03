using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Application.Model
{
    public class ProdutoRequest
    {
        public string nomeProduto { get; set; }

        public decimal valor { get; set; }

        public int quantidadeMl { get; set; }

        public int tipoId { get; set; }

    }
}
