using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWT.HC.API.Entity
{
    [Table("Logo", Schema = "dbo")]
    public class Logo : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoFile { get; set; }
    }
}
