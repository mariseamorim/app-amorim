using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Entities
{
    public class Tratamento
    {
        public Tratamento()
        {
          
        }
        public Tratamento(DateTime? dataInicio, DateTime? dataFim, string medicamento, string lote, string fabricante, string descricao)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            Medicamento = medicamento;
            Lote = lote;
            Fabricante = fabricante;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public string Medicamento { get; private set; }
        public string Lote { get; private set; }
        public string Fabricante { get; private set; }
        public string Descricao { get; private set; }
    }
}
