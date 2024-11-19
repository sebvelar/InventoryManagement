namespace InventoryManagement.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Direccion { get; set; }

        public ICollection<Contacto> Contactos { get; set; }

        public ICollection<OrdenCompraProveedor> OrdenesCompraProveedores { get; set; }
        




    }
}
