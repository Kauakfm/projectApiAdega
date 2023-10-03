using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Repository.Models
{
    public class tabUsuarioFiado
    {
        [Key]
        public int id {  get; set; }

        public int idUsuario { get ; set; }

        public string competencia { get; set; }

        public DateTime dataFiado { get; set; }

        public decimal valor { get; set; }

        public DateTime? dataLiquidacao { get; set; }

        public int? formaPagamento { get; set; }

        public int? valorPago { get; set;}

        public string? observacao { get; set; }


    }
}
