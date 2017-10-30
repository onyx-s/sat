using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnyxSAT.Models
{
    public class Location
    {
        [Key]
        public string RoomNumber { get; set; }
        [Required]
        public string ScannerNumber { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}