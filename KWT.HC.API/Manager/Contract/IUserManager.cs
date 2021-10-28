using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface IUserManager : IManager<HC_UserModel, Guid>
    {
        Task<HC_UserModel> GetUserByEmail(string projectName);
        Task<bool> DeleteUser(Guid Id);
    }
}
