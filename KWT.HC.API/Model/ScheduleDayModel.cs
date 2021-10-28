using EWT.Nuget.Contract.Model;
using System;

namespace KWT.HC.API.Model
{
    public class ScheduleDayModel : IModel<int>
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int Day { get; set; }
        public DateTime DayDate { get; set; }
        public bool Locked { get; set; }
    }
}
