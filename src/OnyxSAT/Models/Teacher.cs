using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class Teacher : User
    {
        public int StaffId { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}