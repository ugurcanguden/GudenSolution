using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities;

namespace Guden.Entities.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string  Email{ get; set; }
        public string Password { get; set; }
    }
}
