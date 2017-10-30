using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
  public class Role
  {
    public int RoleId { get; set; }
    [Required]
    [StringLength(20)]    
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
  }
}