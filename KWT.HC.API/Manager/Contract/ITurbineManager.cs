using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface ITurbineManager : IManager<TurbineModel, int>
    {       
        Task<bool> DeleteById(int Id);
        Task<List<TurbineModel>> GetTurbinesByScheduleId(int scheduleId);
    }
}
