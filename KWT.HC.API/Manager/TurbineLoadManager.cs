using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace KWT.HC.API.Manager
{
    public class TurbineLoadManager : ManagerBase<TurbineLoadModel, ITurbineLoadAccessor, int>, ITurbineLoadManager
    {
        public TurbineLoadManager(ITurbineLoadAccessor accessor) : base(accessor)
        {
        }

        public async Task<bool> DeleteById(int Id)
        {
            return await accessor.DeleteById(Id);
        }
        public async Task<int> DeleteByTurbineId(int turbineId)
        {
            return await accessor.DeleteByTurbineId(turbineId);
        }
        public async Task<bool> DeleteTurbineTime(int turbineTimeId)
        {
            return await accessor.DeleteTurbineTime(turbineTimeId);
        }
        public async Task<bool> DeleteTurbineTimes(List<int> turbineTimeIds)
        {
            return await accessor.DeleteTurbineTimes(turbineTimeIds);
        }
        public async Task<List<TurbineLoadModel>> GetLoadsByTurbineId(int turbineId)
        {
            return await accessor.GetByTurbineId(turbineId);
        }
        public async Task<List<TurbineLoadModel>> GetLoadsByScheduleId(int scheduleId)
        {
            return await accessor.GetLoadsByScheduleId(scheduleId);
        }
        public async Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleId(int ScheduleDayId)
        {
            return await accessor.GetTurbineTimeByScheduleId(ScheduleDayId);
        }
        public async Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleDayId(int ScheduleDayId)
        {
            return await accessor.GetTurbineTimeByScheduleDayId(ScheduleDayId);
        }
        public async Task<TurbineTimeModel> SaveTurbineTime(TurbineTimeModel model)
        {
            return await accessor.SaveTurbineTime(model);
        }
        public async Task<TurbineTimeModel> UpdateTurbineTime(TurbineTimeModel model)
        {
            return await accessor.UpdateTurbineTime(model);
        }
        public async Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId, int day)
        {
            return await accessor.GetTurbineTimeData(scheduleId, day);
        }
        public async Task<List<TurbineHourModel>> GetTurbineHourData(int scheduleId, int day)
        {
            return await accessor.GetTurbineHourData(scheduleId, day);
        }
        public async Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId)
        {
            return await accessor.GetTurbineTimeData(scheduleId);
        }
        public async Task<List<TurbineHourModel>> GetTurbineHourDataByScheduleId(int scheduleId)
        {
            return await accessor.GetTurbineHourDataByScheduleId(scheduleId);
        }

        public async Task<List<TurbineTimeModel>> SaveTurbineTimes(List<TurbineTimeModel> models)
        {
            return await accessor.SaveTurbineTimes(models);
        }
    }
}
