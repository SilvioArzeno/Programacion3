using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace INTEC.Data.Entities
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String DisplayName { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean Locked { get; set; }
        public DateTime LockedDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}
