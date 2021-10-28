using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class UserManager : ManagerBase<HC_UserModel, IUserAccessor, Guid>, IUserManager
    {
        public UserManager(IUserAccessor accessor) : base(accessor)
        {
        }

        public async Task<HC_UserModel> GetUserByEmail(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new Exception("Email Address cannot be null");
            }

            return await accessor.GetUserByEmail(emailAddress);
        }

        public async Task<bool> DeleteUser(Guid Id)
        {
            return await accessor.DeleteByID(Id);
        }
    }
}
