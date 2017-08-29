using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CardNo { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; } 
    }
}