using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWT.HC.API.Entity
{
    [Table("ActivityNote", Schema = "dbo")]
    public class ActivityNote : IEntity<int>
    {
        public int Id { get; set; }
        public int ScheduleDayId { get; set; }
        public int Position { get; set; }
        public int? ActivityOptionId { get; set; }
        public string Note { get; set; }
        public string Style { get; set; }
    }
}
