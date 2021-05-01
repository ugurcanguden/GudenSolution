using Guden.Business.Abstract.Core;
using Guden.Core.Entities.Concrete.Core;
using Guden.Core.Utilities.Results;
using Guden.Entities.Concrete.Core;
using System;
using Guden.DataAccess.Abstract;
using Guden.DataAccess.Abstract.Core;
using Guden.Business.Abstract;
using System.Collections.Generic;

namespace Guden.Business.Concrete.Core
{
    public class MenuManager : ICore_MenuService
    {


        IMenuDal _menuDal;
        IUserService _userService;
        public MenuManager(IMenuDal menuDal, IUserService userService)
        { 
            _menuDal = menuDal;
            _userService = userService;
        }
        public IDataResult<List<Core_Menus>> GetMenusByUser(int userId)
        {
            var userResult = _userService.GetUserById(userId);
            if (userResult.Data==null)
            {
                return new ErrorDataResult<List<Core_Menus>>(new List<Core_Menus>());
            }
                var resultMenus = _menuDal.GetMenus(userResult.Data);
            return new SuccessDataResult<List<Core_Menus>>(resultMenus);
            
        }
    }
}
