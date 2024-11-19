using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }


        [StringLength(255)]
        public string Descripcion { get; set; }


        public int Existencias { get; set; }

        public float Precio { get; set; }

        public int PorcentajeImpuesto { get; set; }

        public int OrdenCompraId { get; set; }

        public ICollection<OrdenCompraProducto> OrdenCompraProductos { get; set; }




    }
}
