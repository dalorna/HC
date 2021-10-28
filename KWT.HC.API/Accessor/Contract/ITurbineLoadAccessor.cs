using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Accessor.Contract
{
    public interface ITurbineLoadAccessor : IAccessor<TurbineLoadModel, int>
    {
        Task<bool> DeleteById(int Id);
        Task<int> DeleteByTurbineId(int TurbineId);
        Task<bool> DeleteTurbineTime(int turbineTimeId);
        Task<bool> DeleteTurbineTimes(List<int> turbineTimeId);
        Task<List<TurbineLoadModel>> GetByTurbineId(int TurbineId);
        Task<List<TurbineLoadModel>> GetLoadsByScheduleId(int scheudleId);
        Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleId(int ScheduleDayId);
        Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleDayId(int ScheduleDayId);
        Task<TurbineTimeModel> SaveTurbineTime(TurbineTimeModel model);
        Task<TurbineTimeModel> UpdateTurbineTime(TurbineTimeModel model);
        Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId, int day);
        Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId);
        Task<List<TurbineHourModel>> GetTurbineHourData(int scheduleId, int day);
        Task<List<TurbineHourModel>> GetTurbineHourDataByScheduleId(int scheduleId);
        Task<List<TurbineTimeModel>> SaveTurbineTimes(List<TurbineTimeModel> models);
    }
}
