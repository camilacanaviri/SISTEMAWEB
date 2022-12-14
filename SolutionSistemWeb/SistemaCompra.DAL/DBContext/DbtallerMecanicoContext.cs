using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemWebTaller.Entity;

namespace SistemaCompra.DAL.DBContext;

public partial class DbtallerMecanicoContext : DbContext
{
    public DbtallerMecanicoContext()
    {
    }

    public DbtallerMecanicoContext(DbContextOptions<DbtallerMecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CargoMenu> CargoMenus { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<CompraServicio> CompraServicios { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Fichaje> Fichajes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; }

    public virtual DbSet<ServiciosGenerale> ServiciosGenerales { get; set; }

    public virtual DbSet<TipoDocumentoCompra> TipoDocumentoCompras { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = local; database = DBTallerMecanico; Trusted_Connection = true; user=sa ;password=camila124; Encrypt=false ;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__3D0E29B8008F3EF4");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<CargoMenu>(entity =>
        {
            entity.HasKey(e => e.IdCargoMenu).HasName("PK__CargoMen__0AB5DF50F335650D");

            entity.ToTable("CargoMenu");

            entity.Property(e => e.IdCargoMenu).HasColumnName("idCargoMenu");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.CargoMenus)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__CargoMenu__idCar__2B3F6F97");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.CargoMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__CargoMenu__idMen__2C3393D0");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CF2866CC5");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<CompraServicio>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__CompraSe__48B99DB76CE0C5DA");

            entity.ToTable("CompraServicio");

            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("documentoCliente");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdTipoDocumentoCompra).HasColumnName("idTipoDocumentoCompra");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.NumeroCompra)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("numeroCompra");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subTotal");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdTipoDocumentoCompraNavigation).WithMany(p => p.CompraServicios)
                .HasForeignKey(d => d.IdTipoDocumentoCompra)
                .HasConstraintName("FK__CompraSer__idTip__3F466844");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CompraServicios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__CompraSer__idUsu__403A8C7D");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__DetalleC__62C252C1ED3E2C2B");

            entity.ToTable("DetalleCompra");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("idDetalleCompra");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CategoriaServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoriaServicio");
            entity.Property(e => e.DescripcionServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcionServicio");
            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__DetalleCo__idCom__5AEE82B9");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__75D2CED445241FD7");

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("idEmpresa");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreLogo");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.SimboloMoneda)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("simboloMoneda");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<Fichaje>(entity =>
        {
            entity.HasKey(e => e.IdFichaje).HasName("PK__Fichaje__EC61CD2838D0EE84");

            entity.ToTable("Fichaje");

            entity.Property(e => e.IdFichaje).HasColumnName("idFichaje");
            entity.Property(e => e.CambioKms).HasColumnName("cambio_Kms");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdPlaca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPlaca");

            entity.HasOne(d => d.IdPlacaNavigation).WithMany(p => p.Fichajes)
                .HasForeignKey(d => d.IdPlaca)
                .HasConstraintName("FK__Fichaje__idPlaca__46E78A0C");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483535274E7");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.IdMenuMayor).HasColumnName("idMenuMayor");
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("paginaAccion");

            entity.HasOne(d => d.IdMenuMayorNavigation).WithMany(p => p.InverseIdMenuMayorNavigation)
                .HasForeignKey(d => d.IdMenuMayor)
                .HasConstraintName("FK__Menu__idMenuMayo__24927208");
        });

        modelBuilder.Entity<NumeroCorrelativo>(entity =>
        {
            entity.HasKey(e => e.IdNumeroCorrelativo).HasName("PK__NumeroCo__25FB547EB22B3FC0");

            entity.ToTable("NumeroCorrelativo");

            entity.Property(e => e.IdNumeroCorrelativo).HasColumnName("idNumeroCorrelativo");
            entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gestion");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
        });

        modelBuilder.Entity<ServiciosGenerale>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119CC6B2680");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ServiciosGenerales)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Servicios__idCat__36B12243");
        });

        modelBuilder.Entity<TipoDocumentoCompra>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumentoCompra).HasName("PK__TipoDocu__780BB59880866A22");

            entity.ToTable("TipoDocumentoCompra");

            entity.Property(e => e.IdTipoDocumentoCompra).HasColumnName("idTipoDocumentoCompra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6E4197254");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreFoto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__300424B4");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdPlaca).HasName("PK__Vehiculo__39B84B9C0E238427");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.IdPlaca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idPlaca");
            entity.Property(e => e.IdCompra).HasColumnName("idCompra");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__Vehiculo__idComp__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
