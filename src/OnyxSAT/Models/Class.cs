using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        [Required]
        public string DayOfWeek { get; set; }
        [Required] 
        [DataType(DataType.Time)]       
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]                
        public DateTime EndTime { get; set; }
        [Required]        
        public string Location { get; set; }

        public Teacher Teacher { get; set; }
    }
}