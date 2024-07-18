using BackendLeads.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendLeads.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Gestor>()
                .HasIndex(a => a.Cpf)
                .IsUnique();

            builder.Entity<Leads>()
                .HasIndex(a => a.Cpf)
                .IsUnique();
            builder.Entity<Leads>()
               .HasIndex(a => a.Email)
               .IsUnique();
            builder.Entity<Leads>()
              .HasIndex(a => a.Telefone)
              .IsUnique();

            builder.Entity<Leads>()
                .HasMany(a => a.Enderecos)
                .WithOne(b => b.Lead)
                .HasForeignKey(a => a.LeadsId);
                
        }

    }
}
