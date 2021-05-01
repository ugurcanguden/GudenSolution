using Guden.Core.Entities.Concrete.Core;
using System;
using System.Collections.Generic; 

namespace Guden.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Core_User user,List<Core_OperationClaim> operationClaims);
    }
}
