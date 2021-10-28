using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class ScheduleManager : ManagerBase<ScheduleModel, IScheduleAccessor, int>, IScheduleManager
    {
        public ScheduleManager(IScheduleAccessor accessor) : base(accessor)
        {
        }

        public async Task<bool> DeleteScheduleById(int scheduleId)
        {
            return await accessor.DeleteScheduleById(scheduleId);
        }

        public async Task<bool> DeleteScheduleTurbineById(int scheduleId, int turbineId)
        {
            return await accessor.DeleteScheduleTurbineById(scheduleId, turbineId);
        }

        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByScheduleId(int scheduleId)
        {
            return await accessor.GetScheduleTurbineModelsByScheduleId(scheduleId);
        }

        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByTurbineId(int turbineId)
        {
            return await accessor.GetScheduleTurbineModelsByTurbineId(turbineId);
        }
        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModels()
        {
            return await accessor.GetScheduleTurbineModels();
        }
        public async Task<ScheduleTurbineModel> SaveScheduleTurbine(ScheduleTurbineModel models)
        {
            return await accessor.SaveScheduleTurbine(models);
        }
        public async Task<List<ScheduleDayModel>> GetScheduleDaysModelByScheduleId(int scheduleId)
        {
            return await accessor.GetScheduleDaysModelByScheduleId(scheduleId);
        }
        public async Task<ScheduleDayModel> SaveScheduleDay(ScheduleDayModel model)
        {
            return await accessor.SaveScheduleDay(model);
        }
        public async Task<ScheduleDayModel> UpdateScheduleDay(ScheduleDayModel model)
        {
            return await accessor.UpdateScheduleDay(model);
        }

        public async Task<bool> CopySchedule(ScheduleModel schedule)
        {
            return await accessor.CopySchedule(schedule);
        }

        public async Task<bool> AddDay(ScheduleDayModel dayModel)
        {
            return await accessor.AddDay(dayModel);
        }
        public async Task<bool> DeleteDay(ScheduleDayModel dayModel)
        {
            return await accessor.DeleteDay(dayModel);
        }
    }
}
