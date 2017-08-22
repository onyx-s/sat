using System;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class UserRole
    {
        //this should work
        public int User { get; set; }
        public User User { get; set; }

        public string Role { get; set; }
        public Role Role { get; set; }
    }
}