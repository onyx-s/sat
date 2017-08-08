using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class CourseUnit
    {
        public string UnitCode { get; set; }
        public string CourseCode { get; set; }        
        [ForeignKey("UnitCode")]
        public Unit Unit { get; set; }
        [ForeignKey("CourseCode")]
        public Course Course { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}