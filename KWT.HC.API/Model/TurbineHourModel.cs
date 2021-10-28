namespace KWT.HC.API.Model
{
    public class TurbineHourModel
    {
        public int TurbineOrder { get; set; }
        public int TurbineId { get; set; }
        public string TurbineName { get; set; }
        public int HoursOperation { get; set; }
        public int? Day { get; set; }
    }
}
