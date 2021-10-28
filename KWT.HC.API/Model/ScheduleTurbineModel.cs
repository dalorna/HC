using EWT.Nuget.Contract.Model;

namespace KWT.HC.API.Model
{
    public class ScheduleTurbineModel : IModel<int>
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int TurbineId { get; set; }
    }
}
