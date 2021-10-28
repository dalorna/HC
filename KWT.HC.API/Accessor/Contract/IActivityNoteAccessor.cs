using EWT.Nuget.Contract.Accessor;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Accessor.Contract
{
    public interface IActivityNoteAccessor : IAccessor<ActivityNoteModel, int>
    {
        Task<bool> DeleteActivityNoteById(int id);
        Task<bool> DeleteActivityNoteByScheduleDayId(int scheduleDayId);
        Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleDayId(int scheduleDayId);
        Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleId(int scheduleId);
        Task<int> updateNotePosition(int scheduleDayId, int position, bool forward);
        Task<int> pasteAllNotes(int fromScheduleDayId, int toScheduleDayId);
    }
}
