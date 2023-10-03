using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Application.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Cep { get; set; }

        public string? Cidade { get; set; }

        public string? Bairro { get; set; }

        public string? Rua { get; set; }

        public string Numero { get; set; }



    }
}
