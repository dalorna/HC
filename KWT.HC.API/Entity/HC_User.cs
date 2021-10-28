using EWT.Nuget.Contract.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWT.HC.API.Entity
{
    [Table("HC_User", Schema = "dbo")]
    public class HC_User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
    }
}
