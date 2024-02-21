using Microsoft.EntityFrameworkCore;
using SaleHelder.Shared.Entities;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;

namespace Presentation.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> usuario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<FaQ> FaQ { get; set; }
        public DbSet<Issue> Reporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //listo --Richard
            #region renaming tables
            modelBuilder.Entity<Issue>().ToTable("Issue");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Departamento>().ToTable("Department");
            modelBuilder.Entity<Categoria>().ToTable("Category");
            modelBuilder.Entity<FaQ>().ToTable("FaQ");
            #endregion
            #region keys
            modelBuilder.Entity<Issue>().HasKey(i => i.Id);
            modelBuilder.Entity<User>().HasKey(i => i.UserId);
            modelBuilder.Entity<Departamento>().HasKey(i => i.DepartamentoId);
            modelBuilder.Entity<Categoria>().HasKey(i => i.CategoriaId);
            modelBuilder.Entity<FaQ>().HasKey(i => i.FaQId);
            #endregion
            #region Foreign Keys
            modelBuilder.Entity<User>()
             .HasOne(u => u.Departamento)
             .WithMany(d => d.Usuarios)
             .HasForeignKey(u => u.DepartamentoId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Departamento>()
                 .HasOne(d => d.categoria)
                 .WithMany(c => c.Departamentos)
                 .HasForeignKey(d => d.IdCategoria)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FaQ>()
                .HasOne(f => f.departamento)
                .WithMany(d => d.FaQs)
                .HasForeignKey(f => f.IdDepartamento)
                .OnDelete(DeleteBehavior.Cascade);

            #region issue
            modelBuilder.Entity<Issue>()
        .HasOne(i => i.User)
        .WithMany(u => u.issues)
        .HasForeignKey(i => i.IdUsuario)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.FaQ)
                .WithMany(f => f.issues)
                .HasForeignKey(i => i.IdFaq)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
            #endregion


            base.OnModelCreating(modelBuilder);
        }
    }

}
