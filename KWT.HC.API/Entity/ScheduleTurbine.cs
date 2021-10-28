using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWT.HC.API.Entity
{
    [Table("ScheduleTurbine", Schema = "dbo")]
    public class ScheduleTurbine : IEntity<int>
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int TurbineId { get; set; }
    }
}
