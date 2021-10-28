using EWT.Nuget.Contract.Model;

namespace KWT.HC.API.Model
{
    public class TurbineTimeModel : IModel<int>
    {
        public int Id { get; set; }
        public int ScheduleDayId { get; set; }
        public int Time { get; set; }
        public int TurbineId { get; set; }
        public int TurbineLoadId { get; set; }
    }
}
