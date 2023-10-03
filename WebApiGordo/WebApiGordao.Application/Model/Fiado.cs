using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Application.Model
{
    public class Fiado
    {

        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string Competencia { get; set; }

        public DateTime DataFiado { get; set; }

        public decimal Valor { get; set; }

        public DateTime? DataLiquidacao { get; set; }

        public int? FormaPagamento { get; set; }

        public int? ValorPago { get; set; }

        public string? Observacao { get; set; }



    }
}
