using EWT.Nuget.Contract.Manager;
using KWT.HC.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWT.HC.API.Manager.Contract
{
    public interface IActivityNoteManager : IManager<ActivityNoteModel, int>
    {
        Task<bool> DeleteActivityNoteById(int id);
        Task<bool> DeleteActivityNoteByScheduleDayId(int scheduleDayId);
        Task<List<ActivityNoteStyleModel>> GetActivityNoteByScheduleDayId(int scheduleDayId);
        Task<List<ActivityNoteStyleModel>> GetActivityNoteStyleByScheduleId(int scheduleId);
        Task<int> updateNotePosition(int scheduleDayId, int position, bool forward);
        Task<int> pasteAllNotes(int fromScheduleDayId, int toScheduleDayId);
    }
}
