using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Usuario
    {
        [Key]
        public int IdUusario { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }
    }
}
