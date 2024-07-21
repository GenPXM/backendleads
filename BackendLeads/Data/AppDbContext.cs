using BackendLeads.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BackendLeads.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<Leads> Leads { get; set; }
        //public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração para Gestor
            builder.Entity<Gestor>()
                .HasIndex(a => a.Cpf)
                .IsUnique();

            // Configurações para Leads
            builder.Entity<Leads>()
                .HasIndex(a => a.Cpf)
                .IsUnique();

            builder.Entity<Leads>()
               .HasIndex(a => a.Email)
               .IsUnique();

            builder.Entity<Leads>()
              .HasIndex(a => a.Telefone)
              .IsUnique();

            
        }
    }
}
