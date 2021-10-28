using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWT.HC.API.Model
{
    public class TurbineDataModel
    {
        public int Day { get; set; }
        public int DayHour { get; set; }
        public string TurbineName { get; set; }
        public string TurbineType { get; set; }
        public int TurbineOrder { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public int? TurbineTimeId { get; set; }
        public int? ScheduleDayId { get; set; }
        public int? Time { get; set; }
        public int? TurbineId { get; set; }
        public int? TurbineLoadId { get; set; }
    }
}
