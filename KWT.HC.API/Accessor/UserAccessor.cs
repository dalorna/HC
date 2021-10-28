using KWT.HC.API.Entity;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Accessor;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KWT.HC.API.Accessor.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.ApplicationInsights.DataContracts;

namespace KWT.HC.API.Accessor
{
    public class UserAccessor : AccessorBase<HC_UserModel, HC_User, IRepository<HC_User, Guid>, Guid>, IUserAccessor
    {
        public UserAccessor(IRepository<HC_User, Guid> repository, IMapper<HC_UserModel, HC_User, Guid> mapper) : base(repository, mapper)
        {
        }
     
        public async Task<HC_UserModel> GetUserByEmail(string emailAddress)
        {
            var user = await _repository.Context.Set<HC_User>().FirstOrDefaultAsync(f => f.Email.ToLower() == emailAddress.ToLower());
            if (user == null) { user = new HC_User { Active = false, CreatedBy = "", Email = "", FirstName = "", Id = Guid.Empty, LastName = "" }; }
            return _mapper.ToModel(user);
        }

        public async Task<List<HC_UserModel>> GetModelsByQuery(string query)
        {
            var response = await _repository.Context.Set<HC_User>().FromSqlRaw(query).ToListAsync();
            return _mapper.ToModels(response).ToList();
        }

        public async Task<bool> DeleteByID(Guid Id)
        {
            var user = await _repository.Context.Set<HC_User>().FirstOrDefaultAsync(f => f.Id.ToString().ToLower() == Id.ToString().ToLower());
            if (user != null)
            {
                _repository.Context.Set<HC_User>().Remove(user);
                var changes =  _repository.Context.SaveChanges();
                return changes == 1;
                
            }
            return false;
        }
    }
}
