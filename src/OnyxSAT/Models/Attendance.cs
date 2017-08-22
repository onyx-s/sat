using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class Attendance
    {
        [Key]

        [StringLength(6)]
        public string DateTime { get; set; }

        public Boolean Verified { get; set; }

        //public virtual ICollection<Card> Cards { get; set; }
    }
}