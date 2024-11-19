namespace InventoryManagement.Models
{
    public class OrdenCompraProducto
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        public int IdOrdenCompra { get; set; }

        public Producto Producto { get; set; }

        public OrdenCompra OrdenCompra { get; set; }
    }
}
