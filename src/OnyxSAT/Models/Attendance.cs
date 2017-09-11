using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime DateTime { get; set; }
        public Boolean Verified { get; set; }

        public string CardNo { get; set; }    
        [ForeignKey("CardNo")]
        public Card Card { get; set; }
    }
}