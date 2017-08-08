
using System;
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

        public int CardNumber { get; set; }
        public DateTime SessionDateTime { get; set; }        
        [ForeignKey("CardNumber")]
        public Card Card { get; set; }
        [ForeignKey("SessionDateTime")]        
        public Session Session { get; set; }
    }
}