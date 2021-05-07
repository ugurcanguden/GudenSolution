using System;
using System.Collections.Generic;
using Guden.Core.Entities.Concrete.Core;
using Guden.Core.Entities.Utilities;
using Guden.Core.Utilities.Results;
using Guden.Core.Utilities.Security.Jwt;
using Guden.Entities.Dtos;

namespace Guden.Business.Abstract.Core
{
    public interface IAuthService
    {
        IDataResult<Core_User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<Core_User> UpdateUser(UserForRegisterDto userForRegisterDto);
        IDataResult<Core_User> Login(UserForLoginDto userForLoginDto);
        Result UserExists(string email,int? userId);
        IDataResult<AccessToken> CreateAccessToken(Core_User user);
        List<SelectList> GetOperationClaimSelectList();
    }
}
