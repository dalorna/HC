using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;

namespace KWT.HC.API.Accessor.Contract
{
    public interface IUserAccessor : IAccessor<HC_UserModel, Guid>
    {
        Task<HC_UserModel> GetUserByEmail(string emailAddress);
        Task<List<HC_UserModel>> GetModelsByQuery(string query);
        Task<bool> DeleteByID(Guid Id);
    }
}
