using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class TeachingPeriod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Period { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime Year { get; set; }
        [Required]      
        public DateTime StartDate { get; set; }
        [Required]               
        public DateTime EndDate { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}