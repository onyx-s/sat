using System.Collections.Generic;

namespace OnyxSAT.Models
{
    public class Student : User
    {
        public int StudentId { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}