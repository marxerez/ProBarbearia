using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProBarbearia.Domain.Identity;
using ProBarbearia.Domain.Models;
using ProBarbearia.Persistence.Contextos.Mappings;

namespace ProBarbearia.Persistence.Contextos
{
    public class ProBarbeariaContext : IdentityDbContext<User, Role, int,
                                                       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProBarbeariaContext(DbContextOptions<ProBarbeariaContext> options) : base(options)
        {

        }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<EstabelecimentoHorario> EstabelecimentoHorario { get; set; }
        public DbSet<EstabelecimentoUsuario> EstabelecimentoUsuario { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<ProfissionalHorario> ProfissionalHorario { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ServicoProfissional> ServicoProfissonal { get; set; }
        public DbSet<ServicoRealizado> ServicoRealizado { get; set; }
        public DbSet<StatusAgenda> StatusAgenda { get; set; }

        public DbSet<EstabelecimentoNaoRegistradoView> EstabelecimentoNaoRegistradoView { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Entity<User>()
                        .Property(X => X.Id)
                        .UseIdentityColumn()
                        .ValueGeneratedOnAdd();
            //.Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Throw);

            modelBuilder.Entity<UserRole>(userRole =>
               {
                   userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                   userRole.HasOne(ur => ur.Role)
                       .WithMany(r => r.UserRoles)
                       .HasForeignKey(ur => ur.RoleId)
                       .IsRequired();

                   userRole.HasOne(ur => ur.User)
                       .WithMany(r => r.UserRoles)
                       .HasForeignKey(ur => ur.UserId)
                       .IsRequired();
               }
           );

            //Agenda
            modelBuilder.Entity<Agenda>()
                       .HasKey(X => X.Id);

            modelBuilder.Entity<Agenda>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<Agenda>()
                        .HasOne(X => X.UserCliente)
                        .WithMany(X => X.Agendas)
                        .HasForeignKey(X => X.UserClienteId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>()
                        .HasOne(X => X.Profissional)
                        .WithMany(X => X.Agendas)
                        .HasForeignKey(X => X.ProfissionalId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>()
                       .HasOne(X => X.Estabelecimento)
                       .WithMany(X => X.Agendas)
                       .HasForeignKey(X => X.EstabelecimentoId)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>()
                        .HasOne(X => X.Servico)
                        .WithMany(X => X.Agendas)
                        .HasForeignKey(X => X.ServicoID)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>()
                        .HasOne(X => X.StatusAgenda)
                        .WithMany(X => X.Agendas)
                        .HasForeignKey(X => X.StatusAgendaID);
            //Relação 1 : 1
            modelBuilder.Entity<Agenda>()
                       .HasOne<Atendimento>(X => X.Atendimento)
                       .WithOne(X => X.Agenda)
                       .HasForeignKey<Atendimento>(X => X.AgendaId);



            //Atendimento   
            modelBuilder.Entity<Atendimento>()
                        .HasKey(X => X.Id);

            modelBuilder.Entity<Atendimento>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<Atendimento>()
                        .HasOne(X => X.FormaPagamento)
                        .WithMany(X => X.Atendimentos)
                        .HasForeignKey(X => X.FormaPagamentoId)
                        .OnDelete(DeleteBehavior.Restrict);


            //ServicoRealizado
            modelBuilder.Entity<ServicoRealizado>()
                       .HasKey(X => X.Id);

            modelBuilder.Entity<ServicoRealizado>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();


            modelBuilder.Entity<ServicoRealizado>()
                        .HasOne(X => X.Atendimento)
                        .WithMany(X => X.ServicosRealizados)
                        .HasForeignKey(x => x.AtendimentoId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicoRealizado>()
                        .HasOne(X => X.Servico)
                        .WithMany(X => X.ServicosRealizados)
                        .HasForeignKey(x => x.ServicoId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicoRealizado>()
                        .HasOne(X => X.Profissional)
                        .WithMany(X => X.ServicosRealizados)
                        .HasForeignKey(x => x.ProfissionalId)
                        .OnDelete(DeleteBehavior.Restrict);




            //Avaliacao
            modelBuilder.Entity<Avaliacao>()
                       .HasKey(X => X.Id);

            modelBuilder.Entity<Avaliacao>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<Avaliacao>()
                        .HasOne(X => X.User)
                        .WithMany(X => X.Avaliacoes)
                        .HasForeignKey(X => X.UserId);

            modelBuilder.Entity<Avaliacao>()
                        .HasOne(X => X.Estabelecimento)
                        .WithMany(X => X.Avaliacoes)
                        .HasForeignKey(X => X.EstabelecimentoId);

            modelBuilder.Entity<Avaliacao>()
                        .HasOne(X => X.Profissional)
                        .WithMany(X => X.Avaliacoes)
                        .HasForeignKey(X => X.ProfissionalId);

            //Estabelecimento   
            modelBuilder.Entity<Estabelecimento>()
                        .HasKey(X => X.Id);

            modelBuilder.Entity<Estabelecimento>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<Estabelecimento>()
                        .HasOne(X => X.Cidade)
                        .WithMany(X => X.Estabelecimentos)
                        .HasForeignKey(X => X.CidadeId);


            //EstabelecimentoUsuario
            // N : N
            modelBuilder.Entity<EstabelecimentoUsuario>()
                        .HasKey(X => new { X.EstabelecimentoID, X.UserId });

            modelBuilder.Entity<EstabelecimentoUsuario>()
                        .HasOne(X => X.Estabelecimento)
                        .WithMany(X => X.EstabelecimentosUsuarios)
                        .HasForeignKey(X => X.EstabelecimentoID)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstabelecimentoUsuario>()
                        .HasOne(X => X.User)
                        .WithMany(X => X.EstabelecimentosUsuarios)
                        .HasForeignKey(X => X.UserId)
                        .IsRequired();


            //EstabelecimentoHorario
            modelBuilder.Entity<EstabelecimentoHorario>()
                        .HasOne(X => X.Estabelecimento)
                        .WithMany(X => X.EstabelecimentoHorarios)
                        .HasForeignKey(X => X.EstabelecimentoId);

            //EstabelecimentoNaoRegistradoView   
            modelBuilder.Entity<EstabelecimentoNaoRegistradoView>()
                        .ToView("EstabelecimentoNaoRegistradoView")
                        .HasKey(X => X.Id);


            //servico
            modelBuilder.Entity<Servico>()
                        .HasKey(X => X.Id);

            modelBuilder.Entity<Servico>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<Servico>()
                        .HasOne(X => X.Estabelecimento)
                        .WithMany(X => X.Servicos)
                        .HasForeignKey(X => X.EstabelecimentoID);

            //     //Profissional            
            modelBuilder.Entity<Profissional>()
                        .HasKey(X => X.UserId);

            modelBuilder.Entity<Profissional>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();


            //     //1:1
            modelBuilder.Entity<Profissional>()
                        .HasOne<User>(X => X.User)
                        .WithOne(X => X.Profissional);
            // .HasForeignKey<User>(X => X.Id)
            //  .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profissional>()
                        .HasOne(X => X.Estabelecimento)
                        .WithMany(X => X.Profissionais)
                        .HasForeignKey(X => X.EstabelecimentoId);


            //ServicoProfissional

            modelBuilder.Entity<ServicoProfissional>()
                        .HasKey(X => X.Id);

            modelBuilder.Entity<ServicoProfissional>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<ServicoProfissional>()
                        .HasKey(X => new { X.ServicoId, X.ProfissionalId });

            modelBuilder.Entity<ServicoProfissional>()
                        .HasOne(X => X.Profissional)
                        .WithMany(X => X.ServicosProfissionais)
                        .HasForeignKey(X => X.ProfissionalId)
                        .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<ServicoProfissional>()
                        .HasOne(X => X.Servico)
                        .WithMany(X => X.ServicosProfissionais)
                        .HasForeignKey(X => X.ServicoId)
                        .OnDelete(DeleteBehavior.Restrict);

            //Rede Social


            modelBuilder.Entity<RedeSocial>()
                          .HasKey(X => X.Id);

            modelBuilder.Entity<RedeSocial>()
                        .Property(X => X.Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn();

            modelBuilder.Entity<RedeSocial>()
                       .HasOne(X => X.Estabelecimento)
                       .WithMany(X => X.RedesSociais)
                       .HasForeignKey(X => X.EstabelecimentoId);

            modelBuilder.Entity<RedeSocial>()
                        .HasOne(X => X.Profissional)
                        .WithMany(X => X.RedesSociais)
                        .HasForeignKey(X => X.ProfissionalId);

            //Cidade
            modelBuilder.Entity<Cidade>()
                          .HasKey(X => X.Id);

            modelBuilder.Entity<Cidade>()
                         .Property(X => X.Id)
                         .ValueGeneratedNever();


            modelBuilder.Entity<Cidade>()
                        .HasOne(X => X.Estado)
                        .WithMany(X => X.Cidades)
                        .HasForeignKey(X => X.Uf);


            //Estado
            modelBuilder.Entity<Estado>()
                           .HasKey(X => X.Id);


            modelBuilder.Entity<Estado>()
                        .Property(X => X.Id)
                        .ValueGeneratedNever();


            // modelBuilder.Entity<PalestranteEvento>()
            //     .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            // modelBuilder.Entity<Evento>()
            //     .HasMany(e => e.RedesSociais)
            //     .WithOne(rs => rs.Evento)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<Palestrante>()
            //     .HasMany(e => e.RedesSociais)
            //     .WithOne(rs => rs.Palestrante)
            //     .OnDelete(DeleteBehavior.Cascade);

        }



    }
}