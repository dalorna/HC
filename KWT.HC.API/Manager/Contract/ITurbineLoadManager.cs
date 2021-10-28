using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface ITurbineLoadManager : IManager<TurbineLoadModel, int>
    {
        Task<bool> DeleteById(int Id);
        Task<int> DeleteByTurbineId(int turbineId);
        Task<bool> DeleteTurbineTime(int turbineTimeId);
        Task<bool> DeleteTurbineTimes(List<int> turbineTimeIds);
        Task<List<TurbineLoadModel>> GetLoadsByTurbineId(int turbineId);
        Task<List<TurbineLoadModel>> GetLoadsByScheduleId(int scheduleId);
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
