namespace InventoryManagement.Models
{
    public class OrdenCompraProveedor
    {
        public int Id { get; set; }

        public int IdOrdenCompra { get; set; }

        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; }

        public OrdenCompra OrdenCompra { get; set; }

    }
}
