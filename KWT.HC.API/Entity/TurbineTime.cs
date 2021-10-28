using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWT.HC.API.Entity
{
    [Table("TurbineTime", Schema = "dbo")]
    public class TurbineTime : IEntity<int>
    {
        public int Id { get; set; }
        public int ScheduleDayId { get; set; }
        public int Time { get; set; }
        public int TurbineId { get; set; }
        public int TurbineLoadId { get; set; }
    }
}
