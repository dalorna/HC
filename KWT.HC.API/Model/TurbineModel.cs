using EWT.Nuget.Contract.Model;
using System;

namespace KWT.HC.API.Model
{
    public class TurbineModel : IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int TurbineOrder { get; set; }
        public string Color { get; set; }
        public string LineType { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public bool Active { get; set; }
        public short? LoadIncrements { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
