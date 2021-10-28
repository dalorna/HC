using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Model;
using EWT.Nuget.Contract.Mapper;
using EWT.Nuget.Contract.Repository;
using System.Threading.Tasks;
using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KWT.HC.API.Accessor
{
    public class ScheduleAccessor : AccessorBase<ScheduleModel, Schedule, IRepository<Schedule, int>, int>, IScheduleAccessor
    {
        IMapper<ScheduleTurbineModel, ScheduleTurbine, int> _stMapper;
        IMapper<ScheduleDayModel, ScheduleDay, int> _sdMapper;
        public ScheduleAccessor(IRepository<Schedule, int> repository, IMapper<ScheduleModel, Schedule, int> mapper,
            IMapper<ScheduleTurbineModel, ScheduleTurbine, int> stmapper, IMapper<ScheduleDayModel, ScheduleDay, int> sdmapper) : base(repository, mapper)
        {
            _stMapper = stmapper;
            _sdMapper = sdmapper;
        }

        public async Task<bool> DeleteScheduleById(int scheduleId)
        {
            var s = await _repository.Context.Set<Schedule>().FindAsync(scheduleId);
            if (s != null)
            {
                _repository.Context.Set<Schedule>().Remove(s);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;
            }
            return false;
        }

        public async Task<bool> DeleteScheduleTurbineById(int scheduleId, int turbineId)
        {
            var s = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.ScheduleId == scheduleId && w.TurbineId == turbineId).ToListAsync();
            if (s.Count > 0)
            {
                _repository.Context.Set<ScheduleTurbine>().RemoveRange(s);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;
            }
            return false;
        }

        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByScheduleId(int scheduleId)
        {
            var modelList = new List<ScheduleTurbineModel>();
            var st = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.ScheduleId == scheduleId).ToListAsync();
            if (st != null && st.Count > 0)
            {
                st.ForEach(e => modelList.Add(_stMapper.ToModel(e)));
            }

            return modelList;
        }

        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModelsByTurbineId(int turbineId)
        {
            var modelList = new List<ScheduleTurbineModel>();
            var st = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.TurbineId == turbineId).ToListAsync();
            if (st != null && st.Count > 0)
            {
                st.ForEach(e => modelList.Add(_stMapper.ToModel(e)));
            }

            return modelList;
        }

        public async Task<List<ScheduleTurbineModel>> GetScheduleTurbineModels()
        {
            var modelList = new List<ScheduleTurbineModel>();
            var st = await _repository.Context.Set<ScheduleTurbine>().ToListAsync();
            if (st != null && st.Count > 0)
            {
                st.ForEach(e => modelList.Add(_stMapper.ToModel(e)));
            }

            return modelList;
        }
    
        public async Task<ScheduleTurbineModel> SaveScheduleTurbine(ScheduleTurbineModel model)
        {
            var e = _stMapper.ToEntity(model);
            var retEntity = await _repository.Context.Set<ScheduleTurbine>().AddAsync(e);
            await _repository.Context.SaveChangesAsync();

            var s = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.ScheduleId == model.ScheduleId && w.TurbineId == model.TurbineId).ToListAsync();
            if (s.Count() == 1)
            {
                return _stMapper.ToModel(s[0]);
            }
            return new ScheduleTurbineModel();
        }

        public async Task<List<ScheduleDayModel>> GetScheduleDaysModelByScheduleId(int scheduleId)
        {
            var modelList = new List<ScheduleDayModel>();
            var sd = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == scheduleId).ToListAsync();
            if (sd != null && sd.Count > 0)
            {
                sd.ForEach(e => modelList.Add(_sdMapper.ToModel(e)));
            }
            return modelList.OrderBy(o => o.Day).ToList();
        }

        public async Task<ScheduleDayModel> SaveScheduleDay(ScheduleDayModel model)
        {
            var e = _sdMapper.ToEntity(model);
            var retEntity = await _repository.Context.Set<ScheduleDay>().AddAsync(e);
            await _repository.Context.SaveChangesAsync();

            var s = await _repository.Context.Set<ScheduleDay>().OrderByDescending(w => w.Id).FirstAsync();
            return _sdMapper.ToModel(s);
        }

        public async Task<ScheduleDayModel> UpdateScheduleDay(ScheduleDayModel model)
        {
            var e = _sdMapper.ToEntity(model);
            var retEntity = _repository.Context.Set<ScheduleDay>().Update(e);
            await _repository.Context.SaveChangesAsync();

            var s = await _repository.Context.Set<ScheduleDay>().OrderByDescending(w => w.Id).FirstAsync();
            return _sdMapper.ToModel(s);
        }

        public async Task<bool> CopySchedule(ScheduleModel schedule)
        {
            var ScheduleTurbineToCopy = await _repository.Context.Set<ScheduleTurbine>().Where(w => w.ScheduleId == schedule.CopyId).ToListAsync();
            var ScheduleDaysToCopy = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == schedule.CopyId).ToListAsync();
            var dataToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                    join tt in _repository.Context.Set<TurbineTime>() on sd.Id equals tt.ScheduleDayId
                                    where sd.ScheduleId == schedule.CopyId
                                    select new CopyModel { 
                                        day = sd.Day, 
                                        scheduleDayId = tt.ScheduleDayId, 
                                        time = tt.Time, 
                                        turbineId = tt.TurbineId, 
                                        turbineLoadId = tt.TurbineLoadId  
                                    }).ToListAsync();

            var notesToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                     join n in _repository.Context.Set<ActivityNote>() on sd.Id equals n.ScheduleDayId
                                     where sd.ScheduleId == schedule.CopyId
                                     select n
                ).ToListAsync();

            var ScheduleTurbineToSave = new List<ScheduleTurbine>();
            for (int i = 0; i < ScheduleTurbineToCopy.Count; i++)
            {
                ScheduleTurbineToSave.Add(new ScheduleTurbine
                {
                    ScheduleId = schedule.Id,
                    TurbineId = ScheduleTurbineToCopy[i].TurbineId
                }); ;
            }

            _repository.Context.Set<ScheduleTurbine>().AddRange(ScheduleTurbineToSave);
            await _repository.Context.SaveChangesAsync();


            var ScheduleDayToSave = new List<ScheduleDay>();
            for (int i = 0; i < ScheduleDaysToCopy.Count; i++)
            {
                ScheduleDayToSave.Add(new ScheduleDay
                {
                    ScheduleId = schedule.Id,
                    Day = ScheduleDaysToCopy[i].Day,
                    DayDate = ScheduleDaysToCopy[i].Day > 0 ? schedule.DayZero.AddDays(ScheduleDaysToCopy[i].Day) : schedule.DayZero,
                    Locked = false
                }); ;
            }

            _repository.Context.Set<ScheduleDay>().AddRange(ScheduleDayToSave);
            await _repository.Context.SaveChangesAsync();

            var newScheduleDays = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == schedule.Id).ToListAsync();

            var allTurbineTimeToSave = new List<TurbineTime>();
            foreach (ScheduleDay day in ScheduleDaysToCopy)
            {
                var dataToCopyDay = dataToCopy.Where(w => w.day == day.Day).ToList();
                var turbineTimeToSave = new List<TurbineTime>();
                foreach(CopyModel copy in dataToCopyDay)
                {
                    var newScheduleDay = newScheduleDays.First(w => w.Day == copy.day);
                    turbineTimeToSave.Add(new TurbineTime
                    {
                       Time = copy.time,
                       TurbineId = copy.turbineId,
                       TurbineLoadId = copy.turbineLoadId,
                       ScheduleDayId = newScheduleDay.Id
                    });
                }
                allTurbineTimeToSave.AddRange(turbineTimeToSave);
            }

            var allNotesToSave = new List<ActivityNote>();
            foreach (ScheduleDay day in ScheduleDaysToCopy)
            {
                var NotesToCopyDay = notesToCopy.Where(w => w.ScheduleDayId == day.Id).ToList();
                if (notesToCopy.Count > 0)
                {
                    var newScheduleDay = newScheduleDays.First(w => w.Day == day.Day);
                    var activityNoteToSave = new List<ActivityNote>();
                    foreach (ActivityNote copy in NotesToCopyDay)
                    {
                        activityNoteToSave.Add(new ActivityNote
                        {
                            Style = copy.Style,
                            Position = copy.Position,
                            ActivityOptionId = copy.ActivityOptionId,
                            Note = copy.Note,
                            ScheduleDayId = newScheduleDay.Id
                        });
                    }
                    allNotesToSave.AddRange(activityNoteToSave);
                }
            }

            _repository.Context.Set<TurbineTime>().AddRange(allTurbineTimeToSave);
            _repository.Context.Set<ActivityNote>().AddRange(allNotesToSave);
            await _repository.Context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddDay(ScheduleDayModel dayModel)
        {
            var ScheduleDaysToAddjust = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == dayModel.ScheduleId && w.Day >= dayModel.Day).ToListAsync();

            var dataToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                    join tt in _repository.Context.Set<TurbineTime>() on sd.Id equals tt.ScheduleDayId
                                    where sd.ScheduleId == dayModel.ScheduleId && sd.Day > dayModel.Day
                                    select new CopyModel
                                    {
                                        day = sd.Day,
                                        scheduleDayId = tt.ScheduleDayId,
                                        time = tt.Time,
                                        turbineId = tt.TurbineId,
                                        turbineLoadId = tt.TurbineLoadId
                                    }).ToListAsync();

            var notesToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                     join n in _repository.Context.Set<ActivityNote>() on sd.Id equals n.ScheduleDayId
                                     where sd.ScheduleId == dayModel.ScheduleId && sd.Day > dayModel.Day
                                     select n).ToListAsync();

            for (int i = 0; i < ScheduleDaysToAddjust.Count; i++)
            {
                ScheduleDaysToAddjust[i].Day++;
                ScheduleDaysToAddjust[i].DayDate = ScheduleDaysToAddjust[i].DayDate.AddDays(1);
            }

            _repository.Context.Set<ScheduleDay>().UpdateRange(ScheduleDaysToAddjust);
            _repository.Context.Set<ScheduleDay>().Add(new ScheduleDay {
                ScheduleId = dayModel.ScheduleId,
                Day = dayModel.Day,
                DayDate = dayModel.DayDate,
                Locked = false
            });
            await _repository.Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDay(ScheduleDayModel dayModel)
        {
            var ScheduleDaysToAddjust = await _repository.Context.Set<ScheduleDay>().Where(w => w.ScheduleId == dayModel.ScheduleId && w.Day > dayModel.Day).ToListAsync();

            var dataToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                    join tt in _repository.Context.Set<TurbineTime>() on sd.Id equals tt.ScheduleDayId
                                    where sd.ScheduleId == dayModel.ScheduleId && sd.Day > dayModel.Day
                                    select new CopyModel
                                    {
                                        day = sd.Day,
                                        scheduleDayId = tt.ScheduleDayId,
                                        time = tt.Time,
                                        turbineId = tt.TurbineId,
                                        turbineLoadId = tt.TurbineLoadId
                                    }).ToListAsync();

            var notesToCopy = await (from sd in _repository.Context.Set<ScheduleDay>()
                                     join n in _repository.Context.Set<ActivityNote>() on sd.Id equals n.ScheduleDayId
                                     where sd.ScheduleId == dayModel.ScheduleId && sd.Day > dayModel.Day
                                     select n).ToListAsync();

            for (int i = 0; i < ScheduleDaysToAddjust.Count; i++)
            {
                ScheduleDaysToAddjust[i].Day--;
                ScheduleDaysToAddjust[i].DayDate = ScheduleDaysToAddjust[i].DayDate.AddDays(-1);
            }

            _repository.Context.Set<ScheduleDay>().UpdateRange(ScheduleDaysToAddjust);
            _repository.Context.Set<ScheduleDay>().Remove(new ScheduleDay
            {
                Id = dayModel.Id,
                ScheduleId = dayModel.ScheduleId,
                Day = dayModel.Day,
                DayDate = dayModel.DayDate,
                Locked = dayModel.Locked
            });
            await _repository.Context.SaveChangesAsync();
            return true;
        }
    }
}
