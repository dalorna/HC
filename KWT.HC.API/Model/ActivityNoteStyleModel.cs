namespace KWT.HC.API.Model
{
    public class ActivityNoteStyleModel
    {
        public int ActivityNoteId { get; set; }
        public int ScheduleDayId { get; set; }
        public int Position { get; set; }
        public int? ActivityOptionId { get; set; }
        public string ActivityStyle { get; set; }
        public string Note { get; set; }
        public string Style { get; set; }
    }
}
