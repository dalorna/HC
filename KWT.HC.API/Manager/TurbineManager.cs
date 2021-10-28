using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class TurbineManager : ManagerBase<TurbineModel, ITurbineAccessor, int>, ITurbineManager
    {
        public TurbineManager(ITurbineAccessor accessor) : base(accessor)
        {
        }

        public async Task<bool> DeleteById(int Id)
        {
            return await accessor.DeleteById(Id);
        }
        public async Task<List<TurbineModel>> GetTurbinesByScheduleId(int scheduleId)
        {
            return await accessor.GetTurbinesByScheduleId(scheduleId);
        }
    }
}
