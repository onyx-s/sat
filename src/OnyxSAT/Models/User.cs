using System;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class User
    {
        //this should work
        public int userId { get; set; }
        [StringLength(50)]
        public string firstName { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public date dateOfBirth { get; set; }
        [StringLength(10)]
        public string gender { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int mobile { get; set; }
        [StringLength(50)]
        email string { get; set; } 

        public ICollection<UserRole> UserRoles { get; set; }

    }
}