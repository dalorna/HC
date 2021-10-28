using EWT.Nuget.Contract.Model;
using System;
using System.Security.Policy;

namespace KWT.HC.API.Model
{
    public class ScheduleModel : IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DayZero { get; set; }
        public int? CopyId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool Active { get; set; }

    }
}
