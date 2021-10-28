using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace KWT.HC.API.Entity
{
    [Table("TurbineLoad", Schema = "dbo")]
    public class TurbineLoad : IEntity<int>
    {
        public int Id { get; set; }
        public int TurbineId { get; set; }
        public decimal MegaWatt { get; set; }
        public decimal Percentage { get; set; }
        public int BTU { get; set; }
        public bool NoLoad { get; set; }
    }
}
