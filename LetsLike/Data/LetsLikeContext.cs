using LetsLike.Configurations;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Data
{
    public class LetsLikeContext : DbContext
    {
        DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        public LetsLikeContext(DbContextOptions<LetsLikeContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=localhost\\SQLEXPRESS;Database=letslike;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration);
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration);

        }


    }
}
