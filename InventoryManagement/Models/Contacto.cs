namespace InventoryManagement.Models
{
    public class Contacto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Titulo { get; set; }

        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; }

    }
}
