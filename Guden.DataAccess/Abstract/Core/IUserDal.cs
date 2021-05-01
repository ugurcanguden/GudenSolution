
using System.Collections.Generic;
using Guden.Core.DataAccess;
using Guden.Core.Entities.Concrete.Core;

namespace Guden.DataAccess.Abstract.Core
{
    public interface IUserDal : IEntityRepository<Core_User>
    {
        List<Core_OperationClaim> GetClaims(Core_User user);

    }
}
