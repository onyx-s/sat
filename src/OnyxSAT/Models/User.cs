using System;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class User
    {
        //this should work
        public int UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public date DateOfBirth { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; } 

        public ICollection<UserRole> UserRoles { get; set; }

    }
}