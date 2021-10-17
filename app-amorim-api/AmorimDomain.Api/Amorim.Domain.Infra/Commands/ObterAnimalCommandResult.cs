using Amorim.Domain.Commands.Contracts;
using Amorim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Commands
{
    public class ObterAnimalCommandResult: ICommandResult
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DateNascimento { get; set; }
        public string NomeMae { get; set; }
        public string GTA { get; set; }
        public double? QuantidadeLeite { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool? possuiTratamento { get; set; }
        public int? Baixa { get; set; }
    }
}
