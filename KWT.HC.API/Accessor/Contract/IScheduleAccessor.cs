using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using System.Collections.Generic;
using KWT.HC.API.Model;

namespace KWT.HC.API.Accessor.Contract
{
    public interface IScheduleAccessor : IAccessor<ScheduleModel, int>
    {
        Task<bool> DeleteScheduleTurbineById(int scheduleId, int turbineId);
        Task<bool> DeleteScheduleById(int scheduleId);
        Task<ScheduleTurbineModel> SaveScheduleTurbine(ScheduleTurbineModel models);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByScheduleId(int scheduleId);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByTurbineId(int turbineId);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModels();
        Task<List<ScheduleDayModel>> GetScheduleDaysModelByScheduleId(int scheduleId);
        Task<ScheduleDayModel> SaveScheduleDay(ScheduleDayModel model);
        Task<ScheduleDayModel> UpdateScheduleDay(ScheduleDayModel model);
        Task<bool> CopySchedule(ScheduleModel schedule);
        Task<bool> AddDay(ScheduleDayModel dayModel);
        Task<bool> DeleteDay(ScheduleDayModel dayModel);
    }
}
