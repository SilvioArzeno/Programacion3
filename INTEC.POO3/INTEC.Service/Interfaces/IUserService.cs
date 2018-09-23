using System;
using INTEC.Models.Insfraestructure;
using INTEC.Models.ViewModels;
using INTEC.Service.Base;

namespace INTEC.Service.Interfaces
{
    public interface IUserService : IBaseService<UserViewModel>
    {
        ServiceResult ValidateUser(string username, string password);
    }
}
