using System.Collections.Generic;
using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;

namespace KWT.HC.API.Accessor.Contract
{
    public interface ITurbineAccessor : IAccessor<TurbineModel, int>
    {
        Task<bool> DeleteById(int Id);
        Task<List<TurbineModel>> GetTurbinesByScheduleId(int scheduleId);
    }
}
