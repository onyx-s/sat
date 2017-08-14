using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Enrolment
    {
        public int EnrolmentId { get; set; }
        public string Status { get; set; }
        
        public int ClassId { get; set; }        
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}