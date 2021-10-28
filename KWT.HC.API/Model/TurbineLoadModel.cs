using EWT.Nuget.Contract.Model;
using System;

namespace KWT.HC.API.Model
{
    public class TurbineLoadModel : IModel<int>
    {
        public int Id { get; set; }
        public int TurbineId { get; set; }
        public decimal MegaWatt { get; set; }
        public decimal Percentage { get; set; }
        public int BTU { get; set; }
        public bool NoLoad { get; set; }
    }
}
