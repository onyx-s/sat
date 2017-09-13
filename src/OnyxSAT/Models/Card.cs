using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Card
    {
        [Key]
        public string CardNo { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; } 
    }
}