using EWT.Nuget.Contract.Model;

namespace KWT.HC.API.Model
{
    public class GraphOptionModel : IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string OptionType { get; set; }
    }
}
