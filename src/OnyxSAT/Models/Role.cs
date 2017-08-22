using System;
using System.ComponentModel.DataAnnotations;

namespace OnyxSAT.Models
{
    public class Role
    {
        public int RoleId { get; set; }
		[StringLength(10)]
		public string Name { get; set; }
		[StringLength(100)]
		public string Descriptions { get; set; }
		
		public ICollection<UserRole> UserRoles { get; set; }
    }
}