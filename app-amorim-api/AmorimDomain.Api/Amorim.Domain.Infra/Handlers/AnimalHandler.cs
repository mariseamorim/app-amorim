using Amorim.Domain.Commands;
using Amorim.Domain.Commands.Contracts;
using Amorim.Domain.Entities;
using Amorim.Domain.Handlers.Contracts;
using Amorim.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Handlers
{
    public class AnimalHandler : IHandler<CadastrarAnimalCommand>
    {

        private readonly IAnimalRepository _repository;

        public AnimalHandler(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastrarAnimalCommand command)
        {
            var commandResult = new CommandResult();

            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Ops, não foi possível fazer o cadastro!", command.Notifications);
            }

            var animal = new Animal(command.Nome, command.DataNascimento, command.NomeMae, command.GTA);

            _repository.Create(animal);

            return new GenericCommandResult(true, "Animal salvo", animal); ;
        }

        public ICommandResult Handle(AlterarAnimalCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Ops, não foi possível fazer a alteração!", command.Notifications);
            }

            var animal = _repository.GetById(command.Id);

            if(animal == null)
            {
                animal = _repository.GetByNome(command.Nome);
            }

            if (command.PossuiTratamento) {
                var tratamento = new Tratamento(command.InicioTratamento,command.FimTratamento,command.Medicamento,command.Lote,command.Fabricante,command.Descricao);
                _repository.CreateTratamento(tratamento);
            }

            animal.AlterarAnimal(animal.Id,command.Nome,command.DataNascimento, command.NomeMae, 
                command.GTA,command.QuantidadeLeite, command.DataInicio, command.DataFim, command.Baixa) ;
                
            _repository.Update(animal);

            // Retorna o resultado
            return new GenericCommandResult(true, "Animal Salvo", animal);
        }

        public ICommandResult Handle(ObterAnimalCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Ops, não foi possível localizar o animal !", command.Notifications);
            }

            var animal =  _repository.GetByNome(command.TermoPesquisado);

            if (animal == null)
            {
                int numero;
                try
                {
                    numero = Int32.Parse(command.TermoPesquisado);
                    
                }
                catch 
                {
                    return new GenericCommandResult(false, "Ops, não foi possível localizar o animal !", command.Notifications);
                }

                animal = _repository.GetById(numero);
            }

            if(animal == null)
            {
                return new GenericCommandResult(false, "Ops, não foi possível localizar o animal !", command.Notifications);
            }
            var result = new ObterAnimalCommandResult() {
                Id = animal.Id,
                Nome = animal.Nome,
                GTA = animal.GTA,
                DateNascimento = animal.DataNascimento,
                NomeMae = animal.NomeMae,
                DataInicio = animal.DataInicio,
                DataFim = animal.DataFim,
                Baixa = animal.Baixa
            };

            // Retorna o resultado
            return new GenericCommandResult(true, "Pesquisa Realizada", result);
        }
    }
}
