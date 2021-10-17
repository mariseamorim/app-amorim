using Amorim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Animal>().Property(x => x.Id);
            modelBuilder.Entity<Animal>().Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Animal>().Property(x => x.DataNascimento);
            modelBuilder.Entity<Animal>().Property(x => x.NomeMae).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Animal>().Property(x => x.GTA);
            modelBuilder.Entity<Animal>().Property(x => x.QuantidadeLeite);
            modelBuilder.Entity<Animal>().Property(x => x.DataInicio);
            modelBuilder.Entity<Animal>().Property(x => x.DataFim);
            modelBuilder.Entity<Animal>().Property(x => x.Baixa);

            modelBuilder.Entity<Tratamento>().ToTable("Tratamento");
            modelBuilder.Entity<Tratamento>().Property(x => x.Id);
            modelBuilder.Entity<Tratamento>().Property(x => x.Medicamento).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Tratamento>().Property(x => x.DataInicio);
            modelBuilder.Entity<Tratamento>().Property(x => x.DataFim);
            modelBuilder.Entity<Tratamento>().Property(x => x.Lote);
            modelBuilder.Entity<Tratamento>().Property(x => x.Descricao);
           modelBuilder.Entity<Tratamento>().Property(x => x.Fabricante);

        }
    }
}
