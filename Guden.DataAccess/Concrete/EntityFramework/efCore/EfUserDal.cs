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
    public class EfUserDal:EfEntityRepositoryBase<Core_User, GudenDatabaseContext>,IUserDal
    {
        /// <summary>
        /// User a ait rolleri döndürür.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Core_OperationClaim> GetClaims(Core_User user)
        {
            using (var context =new  GudenDatabaseContext())
            {
                var result = from operationClaim in context.Core_OperationClaims
                             join userOperationClaim in context.Core_UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new Core_OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
