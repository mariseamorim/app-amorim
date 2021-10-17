using Amorim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Repositories
{
    public interface IAnimalRepository
    {
        void Create(Animal animal);
        void Update(Animal animal);
        Animal GetById(long id);
        Animal GetByNome(string nome);
        void CreateTratamento(Tratamento tratamento);
    } 
}
