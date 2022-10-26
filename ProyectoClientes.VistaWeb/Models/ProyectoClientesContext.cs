using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoClientes.VistaWeb.Models
{
    public partial class ProyectoClientesContext : DbContext
    {
        public ProyectoClientesContext()
        {
        }

        public ProyectoClientesContext(DbContextOptions<ProyectoClientesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<InteresesCliente> InteresesClientes { get; set; } = null!;
        public virtual DbSet<TemasIntere> TemasInteres { get; set; } = null!;
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; DataBase=ProyectoClientes;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D59466420775A284");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Creacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.NumeroDocumento).HasMaxLength(10);

                entity.Property(e => e.Telefono).HasMaxLength(8);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Generos__0F834988934B47A9");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Genero1)
                    .HasMaxLength(10)
                    .HasColumnName("Genero");
            });

            modelBuilder.Entity<InteresesCliente>(entity =>
            {
                entity.HasKey(e => e.IdInteresCliente)
                    .HasName("PK__Interese__75FAE126780B4F6C");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TemasIntere>(entity =>
            {
                entity.HasKey(e => e.IdTemaInteres)
                    .HasName("PK__TemasInt__84265BC20C39EBAC");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tema).HasMaxLength(100);
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TiposDoc__3AB3332F135804B1");

                entity.ToTable("TiposDocumento");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.TipoDocumento).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
