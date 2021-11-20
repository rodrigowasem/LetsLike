﻿using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            // setando a primary key
            builder.HasKey(x => x.Id);

            // criando a FK vinculando o objeto virtual que foi criado na tabela de usuário
            builder.HasOne(fk => fk.UsuarioCadastro)
                .WithMany(fk => fk.Projeto)
                .HasForeignKey(fk => fk.IdUsuarioCadastro)
                .HasConstraintName("FK_PROJETO_USUARIO_ID");
        }
    }

   
}
