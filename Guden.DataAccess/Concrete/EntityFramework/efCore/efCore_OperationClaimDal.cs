using Guden.Core.DataAccess.EntityFramework;
using Guden.DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.DataAccess.Abstract.Core;
using Guden.Core.Entities.Concrete.Core;
using System.Linq.Expressions;

namespace Guden.DataAccess.Concrete.EntityFramework.efCore
{
    public class efCore_OperationClaimDal : EfEntityRepositoryBase<Core_OperationClaim, GudenDatabaseContext>, IOperationClaimDal
    {
       
    }
}
