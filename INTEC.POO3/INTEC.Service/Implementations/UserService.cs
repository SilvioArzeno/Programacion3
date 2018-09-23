using System;
using INTEC.Data.Entities;
using INTEC.Helpers.Infraestructure;
using INTEC.Helpers.Utils;
using INTEC.Models.Insfraestructure;
using INTEC.Models.ViewModels;
using INTEC.Repository.Framework;
using INTEC.Service.Base;
using INTEC.Service.Interfaces;

namespace INTEC.Service.Implementations
{
    public class UserService :
    BaseService<UserViewModel, User>, IUserService
    {
        public UserService(
            IRepository<User> userRepository)
            : base(userRepository)
        {

        }

        public ServiceResult ValidateUser(string username, string password)
        {
            ServiceResult serviceResult = new ServiceResult();

            serviceResult.Success = true;
            serviceResult.ResultTitle = Error.GetErrorMessage(Error.CorrectTransaction);
            serviceResult.Messages.Add(Error.GetErrorMessage(Error.CorrectTransaction));
            serviceResult.ResultObject = MapperHelper.Instance.
                Map<User, UserViewModel>(
                    this.Repository.GetAll(i=> i.UserName == username 
                                           && i.Password == password).Data);

            return serviceResult;

        }
    }
}
