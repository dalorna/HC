using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWT.HC.API.Model
{
    public class CopyModel
    {
        public int day { get; set; }
        public int scheduleDayId { get; set; }
        public int time { get; set; }
        public int turbineId { get; set; }
        public int turbineLoadId { get; set; }
    }
}
