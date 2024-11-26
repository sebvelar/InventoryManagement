using InventoryManagement.Areas.Identity.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement.Data;

public class ApplicationDbContext : IdentityDbContext<Usuario>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Creacion de la relacion de Ordenes de Venta Proveedores
        modelBuilder.Entity<OrdenCompraProveedor>()
            .HasOne(ocp => ocp.Proveedor)
            .WithMany(p => p.OrdenesCompraProveedores)
            .HasForeignKey(p => p.IdProveedor);

        modelBuilder.Entity<OrdenCompraProveedor>()
            .HasOne(ocp => ocp.OrdenCompra)
            .WithMany(oc => oc.OrdenesCompraProveedores)
            .HasForeignKey(oc => oc.IdOrdenCompra);

        //=====================================================
        //Creacion de la relacion de Ordenes de Venta Productos
        modelBuilder.Entity<OrdenCompraProducto>()
            .HasOne(ocp => ocp.Producto)
            .WithMany(p => p.OrdenCompraProductos)
            .HasForeignKey(p => p.IdProducto);

        modelBuilder.Entity<OrdenCompraProducto>()
            .HasOne(ocp => ocp.OrdenCompra)
            .WithMany(oc => oc.OrdenesCompraProductos)
            .HasForeignKey(oc => oc.IdOrdenCompra);

        //====================================================
        //Se define la relacion de Proveedores Contactos
        modelBuilder.Entity<Proveedor>()
            .HasMany(c => c.Contactos)
            .WithOne(c => c.Proveedor)
            .HasForeignKey(c => c.IdProveedor);
    }

    public DbSet<Contacto> Contactos { get; set; }

    public DbSet<OrdenCompra> OrdenesCompra { get; set; }

    public DbSet<Producto> Productos { get; set; }

    public DbSet<Proveedor> Proveedores { get; set; }

    public DbSet<OrdenCompraProducto> OrdenesCompraProductos { get; set; }

    public DbSet<OrdenCompraProveedor> OrdenesCompraProveedores { get; set; }

}
