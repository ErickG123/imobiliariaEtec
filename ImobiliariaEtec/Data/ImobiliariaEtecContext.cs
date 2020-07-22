using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImobiliariaEtec.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ImobiliariaEtec.Data
{
    public class ImobiliariaEtecContext : IdentityDbContext<Usuario>
    {
        public ImobiliariaEtecContext (DbContextOptions<ImobiliariaEtecContext> options): base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<TipoEstabelecimento> TipoEstabelecimentos { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
          
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Corretor",
                NormalizedName = "CORRETOR"
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Locatário",
                NormalizedName = "LOCATÁRIO"
            });

            var hasher = new PasswordHasher<Usuario>();
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = ADMIN_ID,
                Nome = "Admin",
                UserName = "admin@imobiliariaetec.com.br",
                NormalizedUserName = "ADMIN@IMOBILIARIAETEC.COM.BR",
                Email = "admin@imobiliariaetec.com.br",
                NormalizedEmail = "ADMIN@IMOBILIARIAETEC.COM.BR",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = hasher.GetHashCode().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

        }

    }
}
