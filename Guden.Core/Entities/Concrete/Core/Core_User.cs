using System;

namespace Guden.Core.Entities.Concrete.Core
{
    public class Core_User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }        
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime ? UpdateDate { get; set; }
        public bool Status { get; set; }

    }
}
