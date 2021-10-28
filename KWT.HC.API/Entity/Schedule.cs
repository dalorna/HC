using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace KWT.HC.API.Entity
{
    [Table("Schedule", Schema = "dbo")]
    public class Schedule : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CopyId { get; set; }
        public DateTime DayZero { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool Active { get; set; }
    }
}
