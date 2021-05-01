using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities;

namespace Guden.Entities.Dtos
{
     
    public  class UserForRegisterDto:IDto
    {
        public int ? Id  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string OperationClaimIds { get; set; }


    }
}
