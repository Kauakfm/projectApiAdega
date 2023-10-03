using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Repository.Models
{
    public class tabUsuario
    {
        [Key]
        public int id { get; set; }
        
        public string nome { get; set; }

        public string telefone { get; set; }

        public DateTime? dataNascimento { get; set; }

        public string sexo { get; set; }
        
        public string cep { get; set; }

        public string? cidade { get; set; }

        public string? bairro { get; set; }

        public string? rua { get; set; }

        public string numero { get; set; }



    }
}
