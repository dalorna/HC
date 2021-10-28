using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Accessor.Contract;
using KWT.HC.API.Manager.Contract;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager
{
    public class ActivityNoteManager : ManagerBase<ActivityNoteModel, IActivityNoteAccessor, int>, IActivityNoteManager
    {
        public ActivityNoteManager(IActivityNoteAccessor accessor) : base(accessor)
        {
        }

        public async Task<bool> DeleteActivityNoteById(int id)
        {
            return await accessor.DeleteActivityNoteById(id);
        }
        public async Task<bool> DeleteActivityNoteByScheduleDayId(int scheduleDayId)
        {
            return await accessor.DeleteActivityNoteByScheduleDayId(scheduleDayId);
        }
        public async Task<List<ActivityNoteStyleModel>> GetActivityNoteByScheduleDayId(int scheduleDayId)
        {
            return await accessor.GetActivityNoteStyleByScheduleDayId(scheduleDayId);
        }

        public async Task<int> updateNotePosition(int scheduleDayId, int position, bool forward)
        {
            return await accessor.updateNotePosition(scheduleDayId, position, forward);
        }

        public async Task<int> pasteAllNotes(int fromScheduleDayId, int toScheduleDayId)
        {
            return await accessor.pasteAllNotes(fromScheduleDayId, toScheduleDayId);
        }
        public async Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleId(int scheduleId)
        {
            return await accessor.GetActivityNoteStyleByScheduleId(scheduleId);
        }
    }
}
