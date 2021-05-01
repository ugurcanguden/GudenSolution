using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.DataAccess.EntityFramework; 
using Guden.Core.Entities.Concrete.Core; 
using Guden.DataAccess.Abstract.Core;
using Guden.DataAccess.Concrete.EntityFramework.Context;
using Guden.Entities.Concrete.Core;

namespace Guden.DataAccess.Concrete.EntityFramework.efCore
{
    public class efCore_MenuDal : EfEntityRepositoryBase<Core_Menus, GudenDatabaseContext>, IMenuDal
    {
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationClaim"></param>
        /// <returns></returns>
        public List<Core_Menus> GetMenus(Core_User core_Users)
        {

            using (var context = new GudenDatabaseContext())
            {
                var result = (from menus in context.Core_Menus
                              join menuOperationClaimRel in context.Core_MenuOperationClaimRel on menus.Id equals menuOperationClaimRel.MenuId
                              join userOperationClaims in context.Core_UserOperationClaims on menuOperationClaimRel.OperationClaimId equals userOperationClaims.OperationClaimId  
                              where userOperationClaims.UserId ==core_Users.Id && menus.Status==1
                              select new Core_Menus
                              {
                                  Id = menus.Id,
                                  Title=menus.Title,
                                  MenuName = menus.MenuName,
                                  Path=menus.Path,
                                  Icon=menus.Icon,                                  
                                  cName=menus.cName
                              }
                              ).ToList();
                return result;
            }
        }

    }
}
