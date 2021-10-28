using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KWT.HC.API.Entity
{
    [Table("ScheduleDay", Schema = "dbo")]
    public class ScheduleDay : IEntity<int>
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int Day { get; set; }
        public DateTime DayDate { get; set; }
        public bool Locked { get; set; }
    }
}
