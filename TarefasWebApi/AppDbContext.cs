using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasWebApi.Models;
using TarefasWebApi.Models.Enums;

namespace TarefasWebApi
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
            .Property(p => p.Descricao)
            .HasMaxLength(255);

            modelBuilder.Entity<Tarefa>()
            .HasData(
                new Tarefa { Codigo = 1, Descricao = "Tomar café da manhã", Status = Status.Pendente},
                new Tarefa { Codigo = 2, Descricao = "Levar as crianças para a escola", Status = Status.Pendente },
                new Tarefa { Codigo = 3, Descricao = "Ir ao trabalho", Status = Status.Pendente });
        }
    }
}
