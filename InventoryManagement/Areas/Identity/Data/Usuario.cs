using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
public class Usuario : IdentityUser
{
    [Required]
    public string SelectedRole { get; set; } // Para seleccionar un rol

    public List<IdentityRole> AvailableRoles { get; set; } = new List<IdentityRole>();
}

