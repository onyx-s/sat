using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoomNumber { get; set; }
        public string ScannerNumber { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}