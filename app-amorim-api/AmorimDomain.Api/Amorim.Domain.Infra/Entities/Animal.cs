using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Entities
{
    public class Animal 
    {

        public Animal()
        {
           
        }
        public Animal(string nome, DateTime dataNascimento, string nomeMae, string gTA)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            NomeMae = nomeMae;
            GTA = gTA;
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string NomeMae { get; private set; }
        public string GTA { get; private set; }
        public double? QuantidadeLeite { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public bool possuiTratamento { get; private set; }
        public int?  Baixa { get; private set; }

        public void AlterarAnimal(long id, string nome, DateTime? dateNascimento, string nomeMae, string gTA, double? quantidadeLeite, DateTime? dataInicio, DateTime? dataFim,int? baixa)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dateNascimento;
            NomeMae = nomeMae;
            GTA = gTA;
            QuantidadeLeite = quantidadeLeite;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Baixa = baixa;
        }

    }
}
