using System;
using System.Collections.Generic; 
using Guden.Core.Entities.Concrete.Core;
using Guden.Core.Utilities.Results;

namespace Guden.Business.Abstract
{
    public interface IUserService
    {
        List<Core_OperationClaim> GetClaims(Core_User user);
        Core_User Add(Core_User user);
        void Update(Core_User user);
        Core_User GetByMail(string email,int ? Id);
        IDataResult<Core_User> GetUserById(int userId);

    }
}
