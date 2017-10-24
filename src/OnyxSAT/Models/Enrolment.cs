using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Enrolment
    {
        public string Status { get; set; }
        
        public int UserId { get; set; } 
        public int ClassId { get; set; }        
        public User User { get; set; }
        public Class Class { get; set; }
    }
}