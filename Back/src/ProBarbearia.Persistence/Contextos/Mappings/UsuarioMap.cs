using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProBarbearia.Domain.Identity;




namespace ProBarbearia.Persistence.Contextos.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("User");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            //                .UseIdentityColumn();

            // // Propriedades
            builder.Property(x => x.PrimeiroNome)
                .IsRequired()
                .HasColumnName("PrimeiroNome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);


           
            // modelBuilder.Entity<UserRole>(userRole =>
            //                 {
            //                     userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            //                     userRole.HasOne(ur => ur.Role)
            //                         .WithMany(r => r.UserRoles)
            //                         .HasForeignKey(ur => ur.RoleId)
            //                         .IsRequired();

            //                     userRole.HasOne(ur => ur.User)
            //                         .WithMany(r => r.UserRoles)
            //                         .HasForeignKey(ur => ur.UserId)
            //                         .IsRequired();
            //                 }
            //             );
            // builder.Property(x => x.Bio);
            // builder.Property(x => x.Email);
            // builder.Property(x => x.Image);
            // builder.Property(x => x.PasswordHash);

            // builder.Property(x => x.Slug)
            //     .IsRequired()
            //     .HasColumnName("Slug")
            //     .HasColumnType("VARCHAR")
            //     .HasMaxLength(80);

            // // Índices
            // builder
            //     .HasIndex(x => x.Slug, "IX_User_Slug")
            //     .IsUnique();

            // // Relacionamentos
            // builder
            //     .HasMany(x => x.ro)
            //     .WithMany(x => x.Users)
            //     .UsingEntity<Dictionary<string, object>>(
            //         "UserRole",
            //         role => role
            //             .HasOne<Role>()
            //             .WithMany()
            //             .HasForeignKey("RoleId")
            //             .HasConstraintName("FK_UserRole_RoleId")
            //             .OnDelete(DeleteBehavior.Cascade),
            //         user => user
            //             .HasOne<User>()
            //             .WithMany()
            //             .HasForeignKey("UserId")
            //             .HasConstraintName("FK_UserRole_UserId")
            //             .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
