using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class Student : User
    {
        public int StudentId { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}