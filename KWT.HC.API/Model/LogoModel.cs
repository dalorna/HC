using EWT.Nuget.Contract.Model;

namespace KWT.HC.API.Model
{
    public class LogoModel : IModel<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoFile { get; set; }
    }
}
