using System;
using INTEC.Data.Entities;
using INTEC.Models.ViewModels;
using INTEC.Repository.Framework;
using INTEC.Service.Base;
using INTEC.Service.Interfaces;

namespace INTEC.Service.Implementations
{
    public class UserProfileService : 
    BaseService<UserProfileViewModel, UserProfile>, IUserProfileService
    {
        public UserProfileService(
            IRepository<UserProfile> userProfileRepository) 
            : base(userProfileRepository)
        {

        }
    }
}
