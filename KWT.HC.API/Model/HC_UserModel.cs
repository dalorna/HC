using EWT.Nuget.Contract.Model;
using System;


namespace KWT.HC.API.Model
{
    public class HC_UserModel : IModel<Guid>
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
