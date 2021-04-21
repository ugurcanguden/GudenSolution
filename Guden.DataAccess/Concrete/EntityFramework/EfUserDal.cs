using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.DataAccess.EntityFramework;
using Guden.Core.Entities.Concrete;
using Guden.DataAccess.Abstract;
using Guden.DataAccess.Concrete.EntityFramework.Context;


namespace Guden.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User, GudenDatabaseContext>,IUserDal
    {
        /// <summary>
        /// User a ait rolleri döndürür.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context =new  GudenDatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
