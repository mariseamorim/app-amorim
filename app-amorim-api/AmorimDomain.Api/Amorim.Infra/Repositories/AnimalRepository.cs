using Amorim.Domain.Entities;
using Amorim.Domain.Repositories;
using Amorim.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Infra.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context)
        {
            _context = context;
        }

        public Animal GetById(long id)
        {
            return _context
                .Animais
                .FirstOrDefault(x => x.Id == id);
        }
        public Animal GetByNome(string nome)
        {
            return _context
                .Animais
                .FirstOrDefault(x => x.Nome == nome);
        }

        public void Create(Animal animal)
        {
            _context.Animais.Add(animal);
            _context.SaveChanges();
        }

        public void Update(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void CreateTratamento(Tratamento tratamento)
        {
            _context.Tratamentos.Add(tratamento);
            _context.SaveChanges();
        }
    }
}
