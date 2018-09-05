using System;
using INTEC.Models.Insfraestructure;

namespace INTEC.Models.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public Int32 UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String BirthPlace { get; set; }
        public byte?[] Picture { get; set; }
    }
}
