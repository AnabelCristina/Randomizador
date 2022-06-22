using Microsoft.EntityFrameworkCore;
using Randomizador.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randomizador.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }
        public virtual DbSet<Personagem> Personagens { get; set; }
        public virtual DbSet<Acao> Acoes { get; set; }
        public virtual DbSet<Lugar> Lugares { get; set; }

        public virtual DbSet<Objeto> Objetos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.Property(x => x.Nome).IsUnicode(false);
                entity.Property(x => x.Franquia).IsUnicode(false);
            });

            modelBuilder.Entity<Acao>(entity =>
            {
                entity.Property(x => x.acaoPersonagem).IsUnicode(false);
            });

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.Property(x => x.lugarPersonagem).IsUnicode(false);
            });

            modelBuilder.Entity<Objeto>(entity =>
            {
                entity.Property(x => x.objeto).IsUnicode(false);
            });
        }
    }
}