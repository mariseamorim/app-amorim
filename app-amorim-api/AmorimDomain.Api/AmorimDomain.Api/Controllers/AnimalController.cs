using Amorim.Domain.Commands;
using Amorim.Domain.Commands.Contracts;
using Amorim.Domain.Entities;
using Amorim.Domain.Handlers;
using Amorim.Domain.Repositories;
using Amorim.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmorimDomain.Api.Controllers
{
    [ApiController]
    [Route("v1/animal/")]
    public class AnimalController : ControllerBase
    {

        private readonly DataContext _context;

        public AnimalController(DataContext context)
        {
            _context = context;
        }
        [Route("cadastrar")]
        [HttpPost]
        public GenericCommandResult Create(
        [FromBody] CadastrarAnimalCommand command,
        [FromServices] AnimalHandler handler
    )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("alterar")]
        [HttpPost]
        public GenericCommandResult Alterar(
        [FromBody] AlterarAnimalCommand command,
        [FromServices] AnimalHandler handler
 )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("pesquisar")]
        [HttpPost]
        public GenericCommandResult PesquisarAnimal([FromServices] AnimalHandler handler, [FromBody] ObterAnimalCommand command )
        {
            var animal = (GenericCommandResult)handler.Handle(command);
            return animal;
        }


    }
}
