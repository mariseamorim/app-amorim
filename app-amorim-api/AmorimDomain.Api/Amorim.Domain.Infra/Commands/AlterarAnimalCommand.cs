using Amorim.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Commands.Contracts
{
    public class AlterarAnimalCommand : Notifiable<Notification>, ICommand
    {
        public AlterarAnimalCommand()
        {
            
        }
        public AlterarAnimalCommand(long id, string nome, DateTime? dataNascimento, string nomeMae, string gTA, double? quantidadeLeite, DateTime? dataInicio, DateTime? dataFim, int? baixa)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            NomeMae = nomeMae;
            GTA = gTA;
            QuantidadeLeite = quantidadeLeite;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Baixa = baixa;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string GTA { get; set; }
        public double? QuantidadeLeite { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool PossuiTratamento { get;  set; }
        public DateTime? InicioTratamento { get; set; }
        public DateTime? FimTratamento { get; set; }
        public string Medicamento { get; set; }
        public string Lote { get; set; }
        public string Fabricante { get; set; }
        public string Descricao { get; set; }
        public int?  Baixa { get;  set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notifiable<Notification>>()
                .Requires()
                .IsTrue(!String.IsNullOrEmpty(Nome) || this.Id >= 0, "Parâmetros", "Parâmetros para busca não informados"));
        }
       
    }
}
