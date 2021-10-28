using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KWT.HC.API.Accessor
{

    public class TurbineLoadAccessor : AccessorBase<TurbineLoadModel, TurbineLoad, IRepository<TurbineLoad, int>, int>, ITurbineLoadAccessor
    {
        readonly IMapper<TurbineTimeModel, TurbineTime, int> _ttMapper;
        public TurbineLoadAccessor(IRepository<TurbineLoad, int> repository, IMapper<TurbineLoadModel, TurbineLoad, int> mapper,
            IMapper<TurbineTimeModel, TurbineTime, int> ttmapper) : base(repository, mapper)
        {
            _ttMapper = ttmapper;
        }

        public async Task<bool> DeleteById(int Id)
        {
            var load = await _repository.Context.Set<TurbineLoad>().FindAsync(Id);
            if (load != null)
            {
                _repository.Context.Set<TurbineLoad>().Remove(load);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;

            }
            return false;
        }
        public async Task<int> DeleteByTurbineId(int TurbineId)
        {
            string query = string.Format("SELECT * FROM TurbineLoad WHERE TurbineID = {0}", TurbineId);
            var loads = await _repository.Context.Set<TurbineLoad>().FromSqlRaw(query).ToListAsync();
            if (loads.Count > 0)
            {
                _repository.Context.Set<TurbineLoad>().RemoveRange(loads);
                return _repository.Context.SaveChanges();
            }
            return 0;
        }
        public async Task<bool> DeleteTurbineTime(int turbineTimeId)
        {
            var time = await _repository.Context.Set<TurbineTime>().FindAsync(turbineTimeId);
            if (time != null)
            {
                _repository.Context.Set<TurbineTime>().Remove(time);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;

            }
            return false;
        }
        public async Task<bool> DeleteTurbineTimes(List<int> turbineTimeIds)
        {
            var time = await _repository.Context.Set<TurbineTime>().Where(w => turbineTimeIds.Contains(w.Id)).ToListAsync();
            if (time != null)
            {
                _repository.Context.Set<TurbineTime>().RemoveRange(time);
                var changes = _repository.Context.SaveChanges();
                return changes == turbineTimeIds.Count;

            }
            return false;

        }
        public async Task<List<TurbineLoadModel>> GetByTurbineId(int TurbineId)
        {
            var modelList = new List<TurbineLoadModel>();
            string query = string.Format("SELECT * FROM TurbineLoad WHERE TurbineID = {0}", TurbineId);
            var loads = await _repository.Context.Set<TurbineLoad>().FromSqlRaw(query).ToListAsync();
            if (loads != null && loads.Count > 0)
            {
                loads.ForEach(e => modelList.Add(_mapper.ToModel(e)));
            }

            return modelList;
        }
        public async Task<List<TurbineLoadModel>> GetLoadsByScheduleId(int scheduleId)
        {
            var modelList = new List<TurbineLoadModel>();
            string query = string.Format(@"SELECT tl.Id, tl.TurbineId, tl.MegaWatt, tl.Percentage, tl.BTU, tl.NoLoad
                                            FROM TurbineLoad tl
                                            INNER JOIN Turbine t on tl.TurbineId = t.Id
                                            INNER JOIN ScheduleTurbine st on t.Id = st.TurbineId
                                            WHERE st.ScheduleId = {0}", scheduleId);
            var loads = await _repository.Context.Set<TurbineLoad>().FromSqlRaw(query).ToListAsync();
            if (loads != null && loads.Count > 0)
            {
                loads.ForEach(e => modelList.Add(_mapper.ToModel(e)));
            }

            return modelList;
        }
        public async Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleId(int ScheduleId)
        {
            var modelList = new List<TurbineTimeModel>();
            var sd = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == ScheduleId).ToListAsync();
            if (sd != null && sd.Count > 0)
            {
                var days = sd.Select(s => s.Id);
                var tt = await _repository.Context.Set<TurbineTime>().Where(w => days.Contains(w.ScheduleDayId)).ToListAsync();
                tt.ForEach(e => modelList.Add(_ttMapper.ToModel(e)));
            }
            return modelList;
        }
        public async Task<List<TurbineTimeModel>> GetTurbineTimeByScheduleDayId(int ScheduleDayId)
        {
            var modelList = new List<TurbineTimeModel>();
            var sd = await _repository.Context.Set<TurbineTime>().Where(w => w.ScheduleDayId == ScheduleDayId).ToListAsync();
            if (sd != null && sd.Count > 0)
            {
                sd.ForEach(e => modelList.Add(_ttMapper.ToModel(e)));
            }
            return modelList;
        }
        public async Task<TurbineTimeModel> SaveTurbineTime(TurbineTimeModel model)
        {
            var e = _ttMapper.ToEntity(model);
            var retEntity = await _repository.Context.Set<TurbineTime>().AddAsync(e);
            await _repository.Context.SaveChangesAsync();

            var s = await _repository.Context.Set<TurbineTime>().OrderByDescending(w => w.Id).FirstAsync();
            return _ttMapper.ToModel(s);
        }
        public async Task<TurbineTimeModel> UpdateTurbineTime(TurbineTimeModel model)
        {
            var e = _ttMapper.ToEntity(model);
            var retEntity = _repository.Context.Set<TurbineTime>().Update(e);
            await _repository.Context.SaveChangesAsync();
            return _ttMapper.ToModel(retEntity.Entity);
        }
        public async Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId, int day)
        {
            string query = string.Format(@"SELECT sd.Day, sd.DayHour, sd.Id as [ScheduleDayId], t.[Min], t.[Max], t.[Name] as [TurbineName],
                                                  t.[Type] as [TurbineType], t.Id as [TurbineId],
                                                  t.TurbineOrder, tt.Id as [TurbineTimeId], tt.[Time], tt.TurbineLoadId
                                          FROM ScheduleTurbine st
                                          INNER JOIN Turbine t on st.TurbineId = t.Id
                                          INNER JOIN (
                                             SELECT s.Id, s.ScheduleId, s.Day, s.DayDate, h.DayHour
                                             FROM ScheduleDay s
                                             CROSS JOIN DayHour h
                                          )sd on st.ScheduleId = sd.ScheduleId  
                                          LEFT OUTER JOIN TurbineTime tt on sd.Id = tt.ScheduleDayId AND sd.DayHour = tt.Time and st.TurbineId = tt.TurbineId
                                          WHERE st.ScheduleId = {0} AND sd.Day = {1}
                                          UNION
                                          SELECT sd.Day, sd.DayHour, sd.Id as [ScheduleDayId], t.[Min], t.[Max], t.[Name] as [TurbineName],
	                                          t.[Type] as [TurbineType], t.Id as [TurbineId],
	                                          t.TurbineOrder, tt.Id as [TurbineTimeId], tt.[Time], tt.TurbineLoadId
                                          FROM ScheduleTurbine st
                                          INNER JOIN Turbine t on st.TurbineId = t.Id
                                          INNER JOIN (
	                                          SELECT s.Id, s.ScheduleId, s.Day, s.DayDate, h.DayHour
	                                          FROM ScheduleDay s
	                                          CROSS JOIN DayHour h
                                          )sd on st.ScheduleId = sd.ScheduleId  
                                          LEFT OUTER JOIN TurbineTime tt on sd.Id = tt.ScheduleDayId AND sd.DayHour = tt.Time and st.TurbineId = tt.TurbineId
                                          WHERE st.ScheduleId = {0} AND sd.Day = {2} AND sd.DayHour = 0
                                          ORDER BY sd.Day, t.TurbineOrder", scheduleId, day, day + 1);
            var data = await _repository.Context.Set<TurbineData>().FromSqlRaw(query).Select(e => 
                new TurbineDataModel
                {
                    Day = e.Day,
                    DayHour = e.DayHour,
                    TurbineName = e.TurbineName,
                    TurbineType = e.TurbineType,
                    TurbineTimeId = e.TurbineTimeId,
                    TurbineOrder = e.TurbineOrder,
                    ScheduleDayId = e.ScheduleDayId,
                    Time = e.Time,
                    TurbineId = e.TurbineId,
                    TurbineLoadId = e.TurbineLoadId,
                    Min = e.Min,
                    Max = e.Max
                }
            ).ToListAsync();

            return data;
        }
        public async Task<List<TurbineHourModel>> GetTurbineHourData(int scheduleId, int day)
        {
            string query = string.Format(@"SELECT ag.TurbineOrder, ag.TurbineId, ag.TurbineName, COUNT(ag.TurbineTimeId) as [HoursOperation]
                                            FROM(
                                            SELECT sd.Day, sd.DayHour, sd.Id as [ScheduleDayId], t.[Name] as [TurbineName], t.[Min], t.[Max],
                                                t.Id as [TurbineId], t.[Type] as [TurbineType], t.TurbineOrder,
                                                tt.Id as [TurbineTimeId], tt.[Time], tt.TurbineLoadId
                                            FROM ScheduleTurbine st
                                            INNER JOIN Turbine t on st.TurbineId = t.Id and t.[Type] = 'Gas'
                                            INNER JOIN(
                                                 SELECT s.Id, s.ScheduleId, s.Day, s.DayDate, h.DayHour
                                                 From ScheduleDay s
                                                 CROSS JOIN DayHour h
                                            )sd on st.ScheduleId = sd.ScheduleId
                                            LEFT OUTER JOIN TurbineTime tt on sd.Id = tt.ScheduleDayId AND sd.DayHour = tt.Time and st.TurbineId = tt.TurbineId
                                            WHERE st.ScheduleId = {0} AND {1} >= sd.Day)ag
                                            GROUP BY ag.TurbineOrder, ag.TurbineId, ag.TurbineName
                                            ORDER BY ag.TurbineOrder", scheduleId, day);
            return await _repository.Context.Set<TurbineHour>().FromSqlRaw(query).Select(s => new TurbineHourModel
            {
                TurbineOrder = s.TurbineOrder,
                TurbineId = s.TurbineId,
                TurbineName = s.TurbineName,
                HoursOperation = s.HoursOperation
            }).ToListAsync();
        }
        public async Task<List<TurbineHourModel>> GetTurbineHourDataByScheduleId(int scheduleId)
        {
            string query = string.Format(@"SELECT agg.TurbineOrder, agg.TurbineId, agg.TurbineName, agg.Day,
                                                SUM([HoursOperation]) OVER(partition by agg.TurbineId ORDER BY agg.Day) as [HoursOperation]
                                            FROM (
	                                            SELECT ag.TurbineOrder, ag.TurbineId, ag.TurbineName, ag.Day, COUNT(ag.TurbineTimeId) as [HoursOperation]
	                                            FROM(
		                                            SELECT sd.Day, sd.DayHour, sd.Id as [ScheduleDayId], t.[Name] as [TurbineName], t.[Min], t.[Max],
			                                            t.Id as [TurbineId], t.[Type] as [TurbineType], t.TurbineOrder,
			                                            tt.Id as [TurbineTimeId], tt.[Time], tt.TurbineLoadId
			                                            FROM ScheduleTurbine st
			                                            INNER JOIN Turbine t on st.TurbineId = t.Id and t.[Type] = 'Gas'
			                                            INNER JOIN(
					                                            SELECT s.Id, s.ScheduleId, s.Day, s.DayDate, h.DayHour
					                                            From ScheduleDay s
					                                            CROSS JOIN DayHour h)sd on st.ScheduleId = sd.ScheduleId
			                                            LEFT OUTER JOIN TurbineTime tt on sd.Id = tt.ScheduleDayId AND sd.DayHour = tt.Time and st.TurbineId = tt.TurbineId
			                                            WHERE st.ScheduleId = {0}
		                                            )ag
		                                            GROUP BY ag.TurbineOrder, ag.TurbineId, ag.TurbineName, ag.Day
	                                            )agg
	                                            GROUP BY agg.TurbineOrder, agg.TurbineId, agg.TurbineName, agg.Day, agg.HoursOperation
                                            ORDER BY agg.TurbineOrder, agg.Day", scheduleId);
            return await _repository.Context.Set<TurbineHour>().FromSqlRaw(query).Select(s => new TurbineHourModel
            {
                TurbineOrder = s.TurbineOrder,
                TurbineId = s.TurbineId,
                TurbineName = s.TurbineName,
                HoursOperation = s.HoursOperation,
                Day = s.Day
            }).ToListAsync();
        }
        public async Task<List<TurbineDataModel>> GetTurbineTimeData(int scheduleId)
        {
            string query = string.Format(@"SELECT sd.Day, sd.DayHour, sd.Id as [ScheduleDayId], t.[Min], t.[Max], t.[Name] as [TurbineName],
                                                  t.[Type] as [TurbineType], t.Id as [TurbineId],
                                                  t.TurbineOrder, tt.Id as [TurbineTimeId], tt.[Time], tt.TurbineLoadId
                                          FROM ScheduleTurbine st
                                          INNER JOIN Turbine t on st.TurbineId = t.Id
                                          INNER JOIN (
                                             SELECT s.Id, s.ScheduleId, s.Day, s.DayDate, h.DayHour
                                             FROM ScheduleDay s
                                             CROSS JOIN DayHour h
                                          )sd on st.ScheduleId = sd.ScheduleId  
                                          LEFT OUTER JOIN TurbineTime tt on sd.Id = tt.ScheduleDayId AND sd.DayHour = tt.Time and st.TurbineId = tt.TurbineId
                                          WHERE st.ScheduleId = {0}", scheduleId);
            var data = await _repository.Context.Set<TurbineData>().FromSqlRaw(query).Select(e =>
                new TurbineDataModel
                {
                    Day = e.Day,
                    DayHour = e.DayHour,
                    TurbineName = e.TurbineName,
                    TurbineType = e.TurbineType,
                    TurbineTimeId = e.TurbineTimeId,
                    ScheduleDayId = e.ScheduleDayId,
                    Time = e.Time,
                    TurbineId = e.TurbineId,
                    TurbineLoadId = e.TurbineLoadId,
                    TurbineOrder = e.TurbineOrder,
                    Min = e.Min,
                    Max = e.Max
                }
            ).ToListAsync();

            return data;
        }
        public async Task<List<TurbineTimeModel>> SaveTurbineTimes(List<TurbineTimeModel> models)
        {
            var listEntities = new List<TurbineTime>();
            var listModels = new List<TurbineTimeModel>();
            models.ForEach(async model =>
            {
                var e = _ttMapper.ToEntity(model);
                TurbineTime ret = null;
                if (model.Id.Equals(null) || model.Id.Equals(0))
                {
                    var retEntity = await _repository.Context.Set<TurbineTime>().AddAsync(e);
                    ret = retEntity.Entity;

                } else
                {
                    var retEntity = _repository.Context.Set<TurbineTime>().Update(e);
                    ret = retEntity.Entity;
                }
                listEntities.Add(ret);
            });

            await _repository.Context.SaveChangesAsync();

            listEntities.ForEach(e => listModels.Add(_ttMapper.ToModel(e)));

            return listModels;
        }
    }
}
