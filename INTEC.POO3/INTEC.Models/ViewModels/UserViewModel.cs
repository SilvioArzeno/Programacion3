using System;
using System.ComponentModel.DataAnnotations;
using INTEC.Models.Insfraestructure;

namespace INTEC.Models.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        [MaxLength(50)]
        public String UserName { get; set; }

        [MaxLength(50)]
        public String Password { get; set; }

        [MaxLength(254)]
        public String Email { get; set; }

        public String DisplayName { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean Locked { get; set; }
        public DateTime LockedDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}
