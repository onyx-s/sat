using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]        
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]        
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(10)]        
        [RegularExpression(@"^04\d{8}$", ErrorMessage = "That's not a valid mobile number")] 
        public string Mobile { get; set; }
        [MaxLength(20)]                
        public int? StudentId { get; set; }
        [MaxLength(20)]
        public int? StaffId { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}