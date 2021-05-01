using Guden.Core.Utilities.Results;
using Guden.Entities.Concrete.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guden.Business.Abstract.Core
{
    public interface  ICore_MenuService
    {
         
        IDataResult<List<Core_Menus>> GetMenusByUser(int userId);
    }
}
