using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class Card
    {
    //Primary Key
     [StringLength(16)]

     [Key]
     public string CardNo { get; set;}
     public string DateTimeID { get; set;}
     public virtual ICollection<Attendance> Attendances { get; set; }
    }
}