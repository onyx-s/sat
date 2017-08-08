using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UnitCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CourseUnit> CourseUnits { get; set; }
    }
}