﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProBarbearia.Persistence.Contextos;

namespace ProBarbearia.Persistence.Migrations
{
    [DbContext(typeof(ProBarbeariaContext))]
    [Migration("20220910215431_novamigration")]
    partial class novamigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime");

                    b.Property<int>("DiaAgendado")
                        .HasColumnType("int");

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraAgendada")
                        .HasColumnType("datetime");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoID")
                        .HasColumnType("int");

                    b.Property<int>("StatusAgendaID")
                        .HasColumnType("int");

                    b.Property<int?>("UserAtendenteId")
                        .HasColumnType("int");

                    b.Property<int?>("UserClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("ProfissionalId");

                    b.HasIndex("ServicoID");

                    b.HasIndex("StatusAgendaID");

                    b.HasIndex("UserAtendenteId");

                    b.HasIndex("UserClienteId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId")
                        .IsUnique();

                    b.HasIndex("FormaPagamentoId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataComentario")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("ProfissionalId");

                    b.HasIndex("UserId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Ibge")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int?>("Uf")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Uf");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereço")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleMaps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformacaoAdicional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoMarcaImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Estabelecimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.EstabelecimentoHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraAbertura")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HoraFechamento")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("EstabelecimentoHorario");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.EstabelecimentoUsuario", b =>
                {
                    b.Property<int>("EstabelecimentoID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("EstabelecimentoID", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EstabelecimentoUsuario");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Estado", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Ddd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Ibge")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int?>("Pais")
                        .HasColumnType("int");

                    b.Property<string>("Uf")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("decricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Profissional", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");


                    b.Property<int>("EstabelecimentoId")
                        .HasColumnType("int");


                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("EstabelecimentoId");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ProfissionalHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaSemana")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraAbertura")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HoraFechamento")
                        .HasColumnType("datetime");
                        
                    b.Property<DateTime>("DuracaoAtendimento")
                    .HasColumnType("int");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("ProfissionalHorario");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EstabelecimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("RedeSocial");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstabelecimentoID")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoID");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ServicoProfissional", b =>
                {
                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("ServicoId", "ProfissionalId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("ServicoProfissonal");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ServicoRealizado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AtendimentoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("int");

                    b.Property<decimal>("QtdServico")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtendimentoId");

                    b.HasIndex("ProfissionalId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoRealizado");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.StatusAgenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusAgenda");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Agenda", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Agendas")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany("Agendas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProBarbearia.Domain.Models.Servico", "Servico")
                        .WithMany("Agendas")
                        .HasForeignKey("ServicoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Models.StatusAgenda", "StatusAgenda")
                        .WithMany("Agendas")
                        .HasForeignKey("StatusAgendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Identity.User", "UserAtendente")
                        .WithMany()
                        .HasForeignKey("UserAtendenteId");

                    b.HasOne("ProBarbearia.Domain.Identity.User", "UserCliente")
                        .WithMany("Agendas")
                        .HasForeignKey("UserClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Estabelecimento");

                    b.Navigation("Profissional");

                    b.Navigation("Servico");

                    b.Navigation("StatusAgenda");

                    b.Navigation("UserAtendente");

                    b.Navigation("UserCliente");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Atendimento", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Agenda", "Agenda")
                        .WithOne("Atendimento")
                        .HasForeignKey("ProBarbearia.Domain.Models.Atendimento", "AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("Atendimentos")
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("FormaPagamento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Avaliacao", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("EstabelecimentoId");

                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ProfissionalId");

                    b.HasOne("ProBarbearia.Domain.Identity.User", "User")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UserId");

                    b.Navigation("Estabelecimento");

                    b.Navigation("Profissional");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Cidade", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("Uf");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Estabelecimento", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Cidade", "Cidade")
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.EstabelecimentoHorario", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("EstabelecimentoHorarios")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.EstabelecimentoUsuario", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("EstabelecimentosUsuarios")
                        .HasForeignKey("EstabelecimentoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Identity.User", "User")
                        .WithMany("EstabelecimentosUsuarios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.FormaPagamento", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("FormasPagamentos")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Profissional", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Profissionais")
                        .HasForeignKey("EstabelecimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Identity.User", "User")
                        .WithOne("Profissional")
                        .HasForeignKey("ProBarbearia.Domain.Models.Profissional", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ProfissionalHorario", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.RedeSocial", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EstabelecimentoId");

                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany("RedesSociais")
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Estabelecimento");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Servico", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Estabelecimento", "Estabelecimento")
                        .WithMany("Servicos")
                        .HasForeignKey("EstabelecimentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ServicoProfissional", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany("ServicosProfissionais")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Models.Servico", "Servico")
                        .WithMany("ServicosProfissionais")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Profissional");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.ServicoRealizado", b =>
                {
                    b.HasOne("ProBarbearia.Domain.Models.Atendimento", "Atendimento")
                        .WithMany("ServicosRealizados")
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProBarbearia.Domain.Models.Profissional", "Profissional")
                        .WithMany("ServicosRealizados")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProBarbearia.Domain.Models.Servico", "Servico")
                        .WithMany("ServicosRealizados")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("Profissional");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Identity.User", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Avaliacoes");

                    b.Navigation("EstabelecimentosUsuarios");

                    b.Navigation("Profissional");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Agenda", b =>
                {
                    b.Navigation("Atendimento");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Atendimento", b =>
                {
                    b.Navigation("ServicosRealizados");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Cidade", b =>
                {
                    b.Navigation("Estabelecimentos");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Estabelecimento", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Avaliacoes");

                    b.Navigation("EstabelecimentoHorarios");

                    b.Navigation("EstabelecimentosUsuarios");

                    b.Navigation("FormasPagamentos");

                    b.Navigation("Profissionais");

                    b.Navigation("RedesSociais");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Estado", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.FormaPagamento", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Profissional", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("Avaliacoes");

                    b.Navigation("RedesSociais");

                    b.Navigation("ServicosProfissionais");

                    b.Navigation("ServicosRealizados");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.Servico", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("ServicosProfissionais");

                    b.Navigation("ServicosRealizados");
                });

            modelBuilder.Entity("ProBarbearia.Domain.Models.StatusAgenda", b =>
                {
                    b.Navigation("Agendas");
                });
#pragma warning restore 612, 618
        }
    }
}