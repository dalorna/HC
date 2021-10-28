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
    public class ActivityNoteAccessor : AccessorBase<ActivityNoteModel, ActivityNote, IRepository<ActivityNote, int>, int>, IActivityNoteAccessor
    {
        public ActivityNoteAccessor(IRepository<ActivityNote, int> repository, IMapper<ActivityNoteModel, ActivityNote, int> mapper) : base(repository, mapper)
        {
        }


        public async Task<bool> DeleteActivityNoteById(int id)
        {
            var s = await _repository.Context.Set<ActivityNote>().FindAsync(id);
            if (s != null)
            {
                _repository.Context.Set<ActivityNote>().Remove(s);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;
            }
            return false;
        }
        public async Task<bool> DeleteActivityNoteByScheduleDayId(int scheduleDayId)
        {
            var s = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == scheduleDayId).ToListAsync();
            if (s.Count > 0)
            {
                _repository.Context.Set<ActivityNote>().RemoveRange(s);
                var changes = _repository.Context.SaveChanges();
                return changes == 1;
            }
            return false;

        }
        public async Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleId(int scheduleId)
        {
            return await (from an in _repository.Context.Set<ActivityNote>()
                          join go in _repository.Context.Set<GraphOption>() on an.ActivityOptionId equals go.Id into ans
                          from ango in ans.DefaultIfEmpty()
                          join sd in _repository.Context.Set<ScheduleDay>() on an.ScheduleDayId equals sd.Id
                          where sd.ScheduleId == scheduleId
                          select new ActivityNoteStyleModel
                          {
                              ActivityNoteId = an.Id,
                              ScheduleDayId = an.ScheduleDayId,
                              Position = an.Position,
                              Note = an.Note,
                              Style = an.Style,
                              ActivityOptionId = ango.Id,
                              ActivityStyle = ango.Value ?? string.Empty
                          }).ToListAsync();

        }
        public async Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleDayId(int scheduleDayId)
        {
            return await (from an in _repository.Context.Set<ActivityNote>()
                          join go in _repository.Context.Set<GraphOption>() on an.ActivityOptionId equals go.Id into ans
                          from ango in ans.DefaultIfEmpty()
                          where an.ScheduleDayId == scheduleDayId
                          select new ActivityNoteStyleModel {
                              ActivityNoteId = an.Id,
                              ScheduleDayId = an.ScheduleDayId,
                              Position = an.Position,
                              Note = an.Note,
                              Style = an.Style,
                              ActivityOptionId = ango.Id,
                              ActivityStyle = ango.Value ?? string.Empty
                          }).ToListAsync();
        }
        public async Task<int> updateNotePosition(int scheduleDayId, int position, bool delete)
        {
            var entityList = new List<ActivityNote>();
            ActivityNote deleteEntry = new ActivityNote();
            if (delete)
            {
                entityList = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == scheduleDayId && w.Position > position).ToListAsync();
                deleteEntry = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == scheduleDayId && w.Position == position).FirstOrDefaultAsync();
            } else
            {
                entityList = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == scheduleDayId && w.Position >= position).ToListAsync();
            }
            entityList.ForEach(e => {
            if (delete)
                {
                    e.Position--;
                }
            else
                {
                    e.Position++;
                }
            });
            _repository.Context.Set<ActivityNote>().UpdateRange(entityList);
            if (delete && deleteEntry != null)
            {
                _repository.Context.Set<ActivityNote>().Remove(deleteEntry);
            }
            return await _repository.Context.SaveChangesAsync();
        }

        public async Task<int> pasteAllNotes(int fromScheduleDayId, int toScheduleDayId)
        {
            var paste = new List<ActivityNote>();
            var copyNotes = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == fromScheduleDayId).ToListAsync();
            var deleteNotes = await _repository.Context.Set<ActivityNote>().Where(w => w.ScheduleDayId == toScheduleDayId).ToListAsync();
            copyNotes.ForEach(e => paste.Add(new ActivityNote {
                ScheduleDayId = toScheduleDayId,
                Position = e.Position,
                ActivityOptionId = e.ActivityOptionId,
                Note = e.Note,
                Style = e.Style
            }));
            _repository.Context.Set<ActivityNote>().RemoveRange(deleteNotes);
            _repository.Context.Set<ActivityNote>().AddRange(paste);
            return await _repository.Context.SaveChangesAsync();
        }
    }
}
