using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Session
    {
        [Key]
        public DateTime DateTime { get; set; }
        // public string RoomNumber { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public string RoomNumber { get; set; }
        [ForeignKey("RoomNumber")]
        public Location Location { get; set; }
    }
}