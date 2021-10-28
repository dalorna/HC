namespace KWT.HC.API.Entity
{
    public class TurbineHour
    {
        public int TurbineOrder { get; set; }
        public int TurbineId { get; set; }
        public string TurbineName { get; set; }
        public int HoursOperation { get; set; }
        public int? Day { get; set; }
    }
}
