using EWT.Nuget.Contract.Model;

namespace KWT.HC.API.Model
{
    public class ActivityNoteModel : IModel<int>
    {
        public int Id { get; set; }
        public int ScheduleDayId { get; set; }
        public int Position { get; set; }
        public int? ActivityOptionId { get; set; }
        public string Note { get; set; }
        public string Style { get; set; }
    }
}
