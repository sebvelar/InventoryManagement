using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        public int NumeroCompra { get; set; }

        public string Estado { get; set; }

        public int NumeroSeguimiento { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public float MontoTotal { get; set; }

        public ICollection<OrdenCompraProveedor> OrdenesCompraProveedores { get; set; }

        public ICollection<OrdenCompraProducto> OrdenesCompraProductos { get; set; }

        //IDEA
        //Productos que lo componen
        //Una lista de seleccion donde se pueda agregar o quitar productos de la OC
        //Que afecten el monto total de la OC

    }
}
