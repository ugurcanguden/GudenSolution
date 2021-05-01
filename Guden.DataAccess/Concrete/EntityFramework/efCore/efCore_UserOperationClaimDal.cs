using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.DataAccess.EntityFramework;
using Guden.Core.Entities.Concrete.Core;
using Guden.DataAccess.Abstract.Core;
using Guden.DataAccess.Concrete.EntityFramework.Context;

namespace Guden.DataAccess.Concrete.EntityFramework.efCore
{
    public class efCore_UserOperationClaimDal : EfEntityRepositoryBase<Core_UserOperationClaim, GudenDatabaseContext>, IUserOperationClaimDal
    {
        
    }
}
