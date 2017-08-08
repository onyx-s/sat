using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace OnyxSAT.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }  
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }      
    }
}