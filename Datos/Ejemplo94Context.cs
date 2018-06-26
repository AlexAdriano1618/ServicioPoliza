using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entidades;

namespace Datos
{
    public partial class Ejemplo94Context : DbContext
    {
        public Ejemplo94Context(DbContextOptions<Ejemplo94Context> options)
            : base(options)
        {

        }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<ItemMenu> ItemMenu { get; set; }
        public virtual DbSet<LogException> LogException { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }
        public virtual DbSet<Seguro> Seguro { get; set; }
        public virtual DbSet<Siniestro> Siniestro { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=Ejemplo94.mssql.somee.com;Database=Ejemplo94;User Id=Alex_Adriano_SQLLogin_1;password=thp94lf723;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.Estado).HasColumnType("char(1)");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Mail).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion).HasColumnType("char(1)");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemMenu>(entity =>
            {
                entity.HasKey(e => e.IdSubMenu);

                entity.Property(e => e.IdSubMenu).HasColumnName("Id_SubMenu");

                entity.Property(e => e.Estado).HasColumnType("char(10)");

                entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.ItemMenu)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_ITEMMENU_REFERENCE_MENU");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.ItemMenu)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_ITEMMENU_REFERENCE_PERFIL");
            });

            modelBuilder.Entity<LogException>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.Property(e => e.IdLog)
                    .HasColumnName("id_log")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaLog)
                    .HasColumnName("fecha_log")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mensaje).HasColumnType("text");

                entity.Property(e => e.Metodo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Trace).HasColumnType("text");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.Property(e => e.IdLogin)
                    .HasColumnName("Id_login")
                    .ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCambio).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Login_Usuarios");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnType("char(1)");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");

                entity.Property(e => e.Estado).HasColumnType("char(10)");

                entity.Property(e => e.TipoMenu)
                    .HasColumnName("Tipo_Menu")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Url).HasColumnType("text");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo);

                entity.Property(e => e.IdModelo).HasColumnName("Id_Modelo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnType("char(1)");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnType("char(1)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Genero");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasKey(e => e.IdPoliza);

                entity.Property(e => e.IdPoliza).HasColumnName("Id_Poliza");

                entity.Property(e => e.Factura)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCoverturaF)
                    .HasColumnName("Fecha_CoverturaF")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCoverturaI)
                    .HasColumnName("Fecha_CoverturaI")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.NumPoliza)
                    .HasColumnName("numPoliza")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TotValAsegurado)
                    .HasColumnName("Tot_Val_Asegurado")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.TotValPrima)
                    .HasColumnName("Tot_Val_prima")
                    .HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Poliza)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poliza_Clientes");
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.HasKey(e => e.IdSeguro);

                entity.Property(e => e.IdSeguro).HasColumnName("Id_Seguro");

                entity.Property(e => e.IdPoliza).HasColumnName("Id_Poliza");

                entity.Property(e => e.IdVehiculo).HasColumnName("Id_Vehiculo");

                entity.Property(e => e.PrimaSeguro)
                    .HasColumnName("Prima_seguro")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Tasa).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.ValAsegurado)
                    .HasColumnName("Val_asegurado")
                    .HasColumnType("numeric(15, 2)");

                entity.HasOne(d => d.IdPolizaNavigation)
                    .WithMany(p => p.Seguro)
                    .HasForeignKey(d => d.IdPoliza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seguro_Poliza");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Seguro)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_SEGURO_REFERENCE_VEHICULO");
            });

            modelBuilder.Entity<Siniestro>(entity =>
            {
                entity.HasKey(e => e.IdSiniestro);

                entity.Property(e => e.IdSiniestro)
                    .HasColumnName("Id_Siniestro")
                    .ValueGeneratedNever();

                entity.Property(e => e.CallePrincipal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CalleSecundaria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Referencia).HasColumnType("text");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo).HasColumnType("text");

                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.Estado).HasColumnType("char(1)");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion).HasColumnType("char(10)");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Perfil");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.Property(e => e.IdVehiculo)
                    .HasColumnName("Id_Vehiculo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AnioDeFabricacion)
                    .HasColumnName("Anio_De_Fabricacion")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Chasis)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnType("char(1)");

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.Property(e => e.IdModelo).HasColumnName("Id_Modelo");

                entity.Property(e => e.Observaciones).HasColumnType("text");

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Marca");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithOne(p => p.Vehiculo)
                    .HasForeignKey<Vehiculo>(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Modelo");
            });
        }
    }
}
