using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface IScheduleManager : IManager<ScheduleModel, int>
    {
        Task<ScheduleTurbineModel> SaveScheduleTurbine(ScheduleTurbineModel models);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByScheduleId(int scheduleId);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByTurbineId(int turbineId);
        Task<List<ScheduleTurbineModel>> GetScheduleTurbineModels();
        Task<bool> DeleteScheduleTurbineById(int scheduleId, int turbineId);
        Task<bool> DeleteScheduleById(int scheduleId);
        Task<List<ScheduleDayModel>> GetScheduleDaysModelByScheduleId(int scheduleId);
        Task<ScheduleDayModel> SaveScheduleDay(ScheduleDayModel model);
        Task<ScheduleDayModel> UpdateScheduleDay(ScheduleDayModel model);
        Task<bool> CopySchedule(ScheduleModel schedule);
        Task<bool> AddDay(ScheduleDayModel dayModel);
        Task<bool> DeleteDay(ScheduleDayModel dayModel);
    }
}
