using Guden.Core.DataAccess;
using Guden.Core.Entities.Concrete.Core;
using Guden.Entities.Concrete.Core; 
using System.Collections.Generic; 

namespace Guden.DataAccess.Abstract.Core
{
    public interface IMenuDal: IEntityRepository<Core_Menus>
    {
        List<Core_Menus> GetMenus(Core_User core_User);
    }
}
