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
        
        public ICollection<Enrolment> Enrolments { get; set; }
        public ICollection<Session> Sessions { get; set; }
        
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}