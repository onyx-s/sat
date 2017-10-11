using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Attendance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime DateTime { get; set; }
        public Boolean? Verified { get; set; }

        public string CardNo { get; set; } 
        public DateTime? SessionDateTime { get; set; } 
        [ForeignKey("CardNo")]           
        public Card Card { get; set; }
        [ForeignKey("SessionDateTime")]
        public Session Session { get; set; }
    }
}