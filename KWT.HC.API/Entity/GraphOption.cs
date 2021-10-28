using EWT.Nuget.Contract.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace KWT.HC.API.Entity
{
    [Table("GraphOption", Schema = "dbo")]
    public class GraphOption : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string OptionType { get; set; }
    }
}
